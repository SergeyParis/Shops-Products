using System;
using ShopsProducts.SDK;
using ShopsProducts.Data;
using System.Globalization;
using System.Collections.Generic;
using ShopsProducts.SDK.eBay;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace ShopsProducts.ConsoleTest
{
    class Program
    {
        static ShopsProductsContext context = new ShopsProductsContext();

        static void Main(string[] args)
        {
            EBayAPI.AppID = "SergeyPa-oil-PRD-be04e9d4e-5f87abbe";

            //long id = 372277257955;

            //IEnumerable<IDetailsSingleItem> t = EBayAPI.GetProductsDetail(new[] { id }).Result;

            //foreach (var one in t)
            //    foreach (var two in one.ImagesUrl)
            //        Console.WriteLine(two);

            IEnumerable<EBaySingleItem> result = ReadItemsByKeywords(XmlReader.Create("../../../Tests/SDK/Shops/eBay/eBayXmlTest.xml"));

            EBaySingleItem[] expected = new EBaySingleItem[]
            {
                new EBaySingleItem(222946434826, @"Black Diamond Camalot Size #4 C4", @"http://thumbs3.ebaystatic.com/m/momFUog42CqrN67GFqT4s1g/140.jpg",
                                   @"http://rover.ebay.com/rover/1/711-53200-19255-0/1?ff3=2&;toolid=10041&;campid=1234567890&;customid=k-man&;lgeo=1&;vectorid=229466&;item=222946434826",
                                   "US", 46.0m),
                new EBaySingleItem(132606445555, @"BLACK DIAMOND Rock Climbing #3 Camalot CAM", @"http://thumbs4.ebaystatic.com/m/mBhD2PJu3m4eQ48_Xg16JBg/140.jpg",
                                   @"http://rover.ebay.com/rover/1/711-53200-19255-0/1?ff3=2&;toolid=10041&;campid=1234567890&;customid=k-man&;lgeo=1&;vectorid=229466&;item=132606445555",
                                   "US", 20.0m)
            };

            EBaySingleItem[] value2 = result.ToArray();

            for (int i =0; i< expected.Length; i++)
                Console.WriteLine(expected[i] == value2[i]);

            Console.ReadKey();
        }

        private static IEnumerable<EBaySingleItem> ReadItemsByKeywords(XmlReader reader)
        {
            List<EBaySingleItem> items = new List<EBaySingleItem>(20);

            while (reader.Read())
                if (reader.IsStartElement())
                    switch (reader.Name)
                    {
                        case "item":
                            items.Add(new EBaySingleItem());
                            break;
                        case "itemId":
                            reader.Read();
                            items[items.Count - 1].ItemId = Convert.ToInt64(reader.Value.Trim());
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
    }
}
