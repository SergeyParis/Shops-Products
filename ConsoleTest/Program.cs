using System;
using ShopsProducts.SDK.eBay;
using ShopsProducts.Data;

namespace ShopsProducts.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EBayAPI.AppID = "SergeyPa-oil-PRD-be04e9d4e-5f87abbe";
            ShopsProductsContext context = new ShopsProductsContext();
            
            Shop shop = context.Shops.Find(1);
            
            Console.ReadKey();
        }
    }
}
