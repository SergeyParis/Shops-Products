using System;
using ShopProducts.SDK.eBay;
using ShopProducts.Data;

namespace ShopProducts.ConsoleTest
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
