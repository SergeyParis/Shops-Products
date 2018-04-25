using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Xml;

[assembly: InternalsVisibleTo("Tests")]
namespace ShopProducts.SDK.eBay
{
    public static class EBayAPI
    {
        private static string _methodAPISearchByKeywords;
        private static string _serviceVersion;

        public static string AppID { get; set; }

        public static int EntriesPerPage { get; set; } = 100;
        public static int PageNumber { get; set; } = 1;

        static EBayAPI()
        {
            _methodAPISearchByKeywords = eBaySource.API_GetProductsByKeywords_NameMethodAPI;
            _serviceVersion = eBaySource.API_ServicesVersion;
        }

        public static IEnumerable<ISingleItem> GetProducts(string keywords)
        {
            // todo: (if countItems < 0) ==> (read all items)

            XmlReader reader = GetXmlReaderSearchItems(keywords);
            return ReadItems(reader);
        }

        private static XmlReader GetXmlReaderSearchItems(string keywords)
        {
            StringBuilder url = new StringBuilder(eBaySource.API_SevicesURI_FindingService + "?");

            url.Append("OPERATION-NAME=" + HttpUtility.HtmlEncode(_methodAPISearchByKeywords));
            url.Append("&SERVICE-VERSION=" + HttpUtility.HtmlEncode(_serviceVersion));
            url.Append("&SECURITY-APPNAME=" + HttpUtility.HtmlEncode(AppID));
            url.Append("&RESPONSE-DATA-FORMAT=" + "XML");
            url.Append("&keywords=" + HttpUtility.HtmlEncode(keywords));
            url.Append("&paginationInput.entriesPerPage=" + EntriesPerPage.ToString());
            url.Append("&paginationInput.pageNumber=" + PageNumber.ToString());

            return XmlReaderFactory.GetReader(url.ToString());
        }
        private static IEnumerable<EBaySingleItem> ReadItems(XmlReader reader)
        {
            EBaySingleItem[] items = new EBaySingleItem[EntriesPerPage];
            for (int j = 0; j < items.Length; j++)
                items[j] = new EBaySingleItem();

            while (reader.Read())
                if (reader.Name == "item") break;

            int i = 0;
            while (reader.Read() && i < EntriesPerPage)
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
                        case "location":
                            reader.Read();
                            items[i].Location = reader.Value.Trim();
                            break;
                        case "country":
                            reader.Read();
                            items[i].Country = reader.Value.Trim();
                            break;
                        case "currentPrice":
                            items[i].CurrencyName = reader.GetAttribute("currencyId");
                            reader.Read();
                            items[i].Price = Convert.ToDecimal(reader.Value.Trim().Replace('.', ','));
                            break;

                    }

            return items;
        }

        //private static IEnumerable<EBaySingleItem> ReadItems(XmlReader reader)
        //{
        // todo: read all items
        //}
    }
}
