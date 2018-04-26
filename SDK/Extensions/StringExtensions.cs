using System.Collections.Generic;

namespace ShopsProducts.SDK
{
    public static class StringExtensions
    {
        public static IEnumerable<string> StringToImages(this string images)
        {
            if (images.Substring(0, 4) != "http")
                return null;

            string[] s = images.Split(new[] { "http" }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < s.Length; i++)
                s[i] = "http" + s[i];

            return s;
        }
    }
}
