using System;
using ShopsProducts.SDK;
using ShopsProducts.Data;
using System.Globalization;
using System.Collections.Generic;
using ShopsProducts.SDK.eBay;
using System.Linq;

namespace ShopsProducts.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EBayAPI.AppID = "SergeyPa-oil-PRD-be04e9d4e-5f87abbe";
            //ShopsProductsContext context = new ShopsProductsContext();

            IEnumerable<ISingleItem> items = EBayAPI.GetProducts("car").Result;
            long[] ids = items.Select(it => it.Id).ToArray();

            IEnumerable<IDetailsSingleItem> itemsDetails = EBayAPI.GetProductsDetail(ids).Result;
            IEnumerable<SingleItemWrapped> itemsWrapped = items.ToWrapped();

            IDetailsSingleItem[] a = itemsDetails.ToArray();

            Console.ReadKey();
        }
    }
}
