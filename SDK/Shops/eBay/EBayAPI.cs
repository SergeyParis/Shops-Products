using System;
using System.Collections.Generic;
using System.Linq;
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

        static EBayAPI()
        {
            _client = new HttpClient();

            _methodAPISearchByKeywords = eBaySource.API_FindingAPI_findItemsByKeywords;
            _methodAPISearchByIds = eBaySource.API_ShoppingAPI_GetMultipleItems;

            _serviceVersion = eBaySource.API_ServicesVersion;
            _ShoppingApiVersion = eBaySource.API_ShoppingAPI_Version;


        }

        public async static Task<SearchResults> GetProducts(string keywords, int pageIndex = 1)
        {
            Task<XmlReader> task = new Task<XmlReader>((o) => Get_ItemsByKeywords(o), new { keywords = keywords, pageIndex = pageIndex });
            task.Start();

            XmlReader reader = await task;
            IEnumerable<ISingleItem> results = ReadItemsByKeywords(reader);
            return new SearchResults(keywords, pageIndex) { Results = results };
        }
        public async static Task<IEnumerable<IDetailsSingleItem>> GetProductsDetail(IEnumerable<ISingleItem> singleItems)
        {
            long[] ids = singleItems.Select(it => it.Id).ToArray();

            EBayDetailsSingleItem[] result = new EBayDetailsSingleItem[ids.Length];
            int counter = 0;

            long[][] splitIds = SplitTo20(ids);

            for (int i = 0; i < ids.Length / 20; i++)
            {
                HttpContent content = Post_DetailstByIds(splitIds[i]);
                HttpResponseMessage response = await _client.PostAsync(eBaySource.API_SevicesURI_ShoppingApiUrl, content);
                
                XmlDocument document = new XmlDocument();
                document.LoadXml(response.Content.ReadAsStringAsync().Result);

                XmlReader reader = XmlReaderFactory.GetReader(document);
                IEnumerable<EBayDetailsSingleItem> temp = ReadItemsByIds(singleItems, reader);

                foreach (EBayDetailsSingleItem one in temp)
                    result[counter++] = one;
            }

            return result;
        }

        // todo: rewrite to post request
        private static XmlReader Get_ItemsByKeywords(dynamic d)
        {
            string keywords = d.keywords ?? "";
            int pageIndex = d.pageIndex ?? 1;

            StringBuilder url = new StringBuilder(eBaySource.API_SevicesURI_FindingApiUrl + "?");

            url.Append("OPERATION-NAME=" + HttpUtility.HtmlEncode(_methodAPISearchByKeywords));
            url.Append("&SERVICE-VERSION=" + HttpUtility.HtmlEncode(_serviceVersion));
            url.Append("&SECURITY-APPNAME=" + HttpUtility.HtmlEncode(AppID));
            url.Append("&RESPONSE-DATA-FORMAT=" + "XML");
            url.Append("&keywords=" + HttpUtility.HtmlEncode(keywords));
            url.Append("&paginationInput.entriesPerPage=" + EntriesPerPage.ToString());
            url.Append("&paginationInput.pageNumber=" + pageIndex.ToString());

            return XmlReaderFactory.GetReader(url.ToString());
        }
        private static HttpContent Post_DetailstByIds(long[] id)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "X-EBAY-API-APP-ID", AppID},
                { "X-EBAY-API-SITE-ID", "0"},
                { "X-EBAY-API-CALL-NAME", _methodAPISearchByIds},
                { "X-EBAY-API-VERSION", _ShoppingApiVersion},
                { "X-EBAY-API-REQUEST-ENCODING", "xml"}
            };

            XNamespace xNamespace = "urn:ebay:apis:eBLBaseComponents";
            XElement items = new XElement(xNamespace + "GetMultipleItemsRequest");

            foreach (long one in id)
                items.Add(new XElement(xNamespace + "ItemID", one.ToString()));
            XDocument xml = new XDocument(items);

            XmlDocument xxx = new XmlDocument();

            StringContent content = new StringContent("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + xml.ToString());

            Console.WriteLine(xml.ToString());

            xxx.LoadXml(content.ReadAsStringAsync().Result);
            xxx.Save(@"D:\xml.xml");

            content.Headers.Clear();
            foreach (KeyValuePair<string, string> one in headers)
                content.Headers.Add(one.Key, one.Value);

            return content;
        }

        private static IEnumerable<EBaySingleItem> ReadItemsByKeywords(XmlReader reader)
        {
            List<EBaySingleItem> items = new List<EBaySingleItem>(EntriesPerPage);

            while (reader.Read())
                if (reader.IsStartElement())
                    switch (reader.Name)
                    {
                        case "item":
                            items.Add(new EBaySingleItem());
                            break;
                        case "itemId":
                            reader.Read();
                            items[items.Count - 1].Id = Convert.ToInt64(reader.Value.Trim());
                            break;
                        case "title":
                            reader.Read();
                            items[items.Count - 1].Title = reader.Value.Trim();
                            break;
                        case "galleryURL":
                            reader.Read();
                            items[items.Count - 1].GalleryUrl = reader.Value.Trim();
                            break;
                        case "viewItemURL":
                            reader.Read();
                            items[items.Count - 1].Url = reader.Value.Trim();
                            break;
                        case "country":
                            reader.Read();
                            items[items.Count - 1].Country = reader.Value.Trim();
                            break;
                        case "currentPrice":
                            reader.Read();
                            items[items.Count - 1].Price = Convert.ToDecimal(reader.Value.Trim().Replace('.', ','));
                            break;
                    }

            return items.ToArray();
        }
        private static IEnumerable<EBayDetailsSingleItem> ReadItemsByIds(IEnumerable<ISingleItem> singleItems, XmlReader reader)
        {
            ISingleItem[] singleItemsArray = singleItems.ToArray();

            List<EBayDetailsSingleItem> items = new List<EBayDetailsSingleItem>(20);

            while (reader.Name == "Item")
                reader.Read();

            List<string> tempUrls = new List<string>(10);

            while (reader.Read())
                if (reader.IsStartElement())
                    switch (reader.Name)
                    {
                        case "Item":
                            items.Add(new EBayDetailsSingleItem(singleItemsArray[items.Count]));
                            items[items.Count - 1].ImagesUrl = tempUrls.ToArray();
                            tempUrls = new List<string>(10);
                            break;
                        case "PictureURL":
                            reader.Read();
                            tempUrls.Add(reader.Value.Trim());
                            break;
                    }

            return items.ToArray();
        }

        private static long[][] SplitTo20(long[] array)
        {
            long[][] result = new long[array.Length / 20][];

            for (int i = 0; i < array.Length / 20; i++)
                result[i] = new long[20];

            int j = 0;
            int currentArray = 0;
            foreach (long one in array)
            {
                if (j >= 20)
                {
                    currentArray++;
                    j = 0;
                }

                result[currentArray][j++] = one;
            }

            return result;
        }
    }
}
