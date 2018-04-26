using System.Globalization;

namespace ShopsProducts.SDK
{
    public static class CultureFromCountry
    {
        public static CultureInfo GetCulture(string countryName)
        {
            switch (countryName)
            {
                case "US": return CultureInfo.GetCultureInfo("en-US");
                case "RU": return CultureInfo.GetCultureInfo("ru-RU");
                case "CA": return CultureInfo.GetCultureInfo("en-CA");
                case "IE": return CultureInfo.GetCultureInfo("en-IE");
                case "GB": return CultureInfo.GetCultureInfo("en-GB");
                case "UA": return CultureInfo.GetCultureInfo("uk-UA");
                case "PL": return CultureInfo.GetCultureInfo("pl-PL");

                default: return CultureInfo.InvariantCulture;
            }
        }
    }
}
