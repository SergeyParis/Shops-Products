using System;
using ShopsProducts.SDK;
using ShopsProducts.Data;
using System.Globalization;


namespace ShopsProducts.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //EBayAPI.AppID = "SergeyPa-oil-PRD-be04e9d4e-5f87abbe";
            //ShopsProductsContext context = new ShopsProductsContext();

            decimal a = 54.23m;
            Console.WriteLine(string.Format(CultureFromCountry.GetCulture("US"), "{0:C}", a));

            Console.ReadKey();
        }
    }
}
