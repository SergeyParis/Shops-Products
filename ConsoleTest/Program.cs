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
        static ShopsProductsContext context = new ShopsProductsContext();

        static void Main(string[] args)
        {
            EBayAPI.AppID = "SergeyPa-oil-PRD-be04e9d4e-5f87abbe";

            long id = 372277257955;

            IEnumerable<IDetailsSingleItem> t = EBayAPI.GetProductsDetail(new[] { id }).Result;

            foreach (var one in t)
                foreach (var two in one.ImagesUrl)
                    Console.WriteLine(two);

            Console.ReadKey();
        }
    }
}
