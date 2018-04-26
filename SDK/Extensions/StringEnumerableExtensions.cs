using System.Collections.Generic;
using System.Text;

namespace ShopsProducts.SDK
{
    public static class StringEnumerableExtensions
    {
        public static string ImagesToString(this IEnumerable<string> images)
        {
            StringBuilder builder = new StringBuilder(50);

            foreach (string one in images)
                builder.Append(one);

            return builder.ToString();
        }
    }
}
