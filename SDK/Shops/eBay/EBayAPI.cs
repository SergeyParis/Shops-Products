using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

[assembly: InternalsVisibleTo("Tests")]
namespace ShopsProducts.SDK.eBay
{
    public static class EBayAPI
    {
        private static readonly HttpClient _client;

        private static readonly string _methodAPISearchByKeywords;
        private static readonly string _methodAPISearchByIds;

        private static readonly string _serviceVersion;
        private static readonly string _ShoppingApiVersion;

        public static string AppID { get; set; }

        public static int EntriesPerPage { get; set; } = 100;
        public static int PageNumber { get; set; } = 1;

        static EBayAPI()
        {
            _client = new HttpClient();

            _methodAPISearchByKeywords = eBaySource.API_FindingAPI_findItemsByKeywords;
            _methodAPISearchByIds = eBaySource.API_ShoppingAPI_GetMultipleItems;

            _serviceVersion = eBaySource.API_ServicesVersion;
            _ShoppingApiVersion = eBaySource.API_ShoppingAPI_Version;


        }

        public async static Task<IEnumerable<ISingleItem>> GetProducts(string keywords)
        {
            Task<XmlReader> task = new Task<XmlReader>((o) => GetSearchItemsXmlUrl((string)o), keywords);
            task.Start();

            XmlReader reader = await task;
            return ReadItemsByKeywords(reader);
        }
        public async static Task<IEnumerable<IDetailsSingleItem>> GetProductsDetail(long[] ids)
        {
            HttpContent content = CreateContentByIds(ids);
            HttpResponseMessage response = await _client.PostAsync(eBaySource.API_SevicesURI_ShoppingApiUrl, content);

            XmlReader reader = XmlReaderFactory.GetReader(response.Content.ReadAsStringAsync().Result);
            return ReadItemsByIds(ids, reader);
        }

        // todo: rewrite to post request
        private static XmlReader GetSearchItemsXmlUrl(string keywords)
        {
            StringBuilder url = new StringBuilder(eBaySource.API_SevicesURI_FindingApiUrl + "?");

            url.Append("OPERATION-NAME=" + HttpUtility.HtmlEncode(_methodAPISearchByKeywords));
            url.Append("&SERVICE-VERSION=" + HttpUtility.HtmlEncode(_serviceVersion));
            url.Append("&SECURITY-APPNAME=" + HttpUtility.HtmlEncode(AppID));
            url.Append("&RESPONSE-DATA-FORMAT=" + "XML");
            url.Append("&keywords=" + HttpUtility.HtmlEncode(keywords));
            url.Append("&paginationInput.entriesPerPage=" + EntriesPerPage.ToString());
            url.Append("&paginationInput.pageNumber=" + PageNumber.ToString());

            return XmlReaderFactory.GetReader(url.ToString());
        }
        private static HttpContent CreateContentByIds(long[] id)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "X-EBAY-API-APP-ID", AppID},
                { "X-EBAY-API-SITE-ID", "0"},
                { "X-EBAY-API-CALL-NAME", _methodAPISearchByIds},
                { "X-EBAY-API-VERSION", _ShoppingApiVersion},
                { "X-EBAY-API-REQUEST-ENCODING", "xml"}
            };
            
            XElement items = new XElement("GetMultipleItemsRequest");
            items.SetAttributeValue("GetMultipleItemsRequest", "urn:ebay:apis:eBLBaseComponents");

            foreach (long one in id)
                items.Add(new XElement("ItemID", one.ToString()));

            XDocument xml = new XDocument(items);

            StringContent content = new StringContent(xml.ToString(), Encoding.UTF8, "text/xml");
            foreach (KeyValuePair<string, string> one in headers)
                content.Headers.Add(one.Key, one.Value);

            return content;
        }
        
        private static IEnumerable<EBaySingleItem> ReadItemsByKeywords(XmlReader reader)
        {
            List<EBaySingleItem> items = new List<EBaySingleItem>(EntriesPerPage);

            for (int j = 0; j < items.Count; j++)
                items[j] = new EBaySingleItem();

            while (reader.Read())
                if (reader.Name == "item") break;

            int i = 0;
            while (reader.Read())
                if (reader.IsStartElement())
                    switch (reader.Name)
                    {
                        case "item":
                            i++;
                            break;
                        case "itemId":
                            reader.Read();
                            items[i].Id = Convert.ToInt64(reader.Value.Trim());
                            break;
                        case "title":
                            reader.Read();
                            items[i].Title = reader.Value.Trim();
                            break;
                        case "galleryURL":
                            reader.Read();
                            items[i].GalleryUrl = reader.Value.Trim();
                            break;
                        case "viewItemURL":
                            reader.Read();
                            items[i].Url = reader.Value.Trim();
                            break;
                        case "country":
                            reader.Read();
                            items[i].Country = reader.Value.Trim();
                            break;
                        case "currentPrice":
                            reader.Read();
                            items[i].Price = Convert.ToDecimal(reader.Value.Trim().Replace('.', ','));
                            break;
                    }

            return items.ToArray();
        }
        private static IEnumerable<EBayDetailsSingleItem> ReadItemsByIds(long[] id, XmlReader reader)
        {
            List<EBayDetailsSingleItem> items = new List<EBayDetailsSingleItem>(EntriesPerPage);

            for (int j = 0; j < items.Count; j++)
                items[j] = new EBayDetailsSingleItem(id[j]);

            while (reader.Read())
                if (reader.Name == "Item") break;

            int i = 0;
            List<string> tempUrls = new List<string>(10);

            while (reader.Read())
                if (reader.IsStartElement())
                    switch (reader.Name)
                    {
                        case "item":
                            items[i].ImagesUrl = tempUrls.ToArray();
                            tempUrls = new List<string>(10);
                            i++;
                            break;
                        case "PictureURL":
                            reader.Read();
                            tempUrls.Add(reader.Value.Trim());
                            break;
                    }

            return items.ToArray();
        }
    }
}
