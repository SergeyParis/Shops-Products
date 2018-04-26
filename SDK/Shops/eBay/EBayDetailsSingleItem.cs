using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShopsProducts.SDK.eBay
{
    class EBayDetailsSingleItem : IDetailsSingleItem
    {
        public long Id { get; set; }
        public IEnumerable<string> ImagesUrl { get; set; }

        public EBayDetailsSingleItem(long id) : this(id, null) { }
        public EBayDetailsSingleItem(long id, IEnumerable<string> images)
        {
            Id = id;
            ImagesUrl = images;
        }
        
        public static string ImagesToString(IEnumerable<string> images)
        {
            StringBuilder builder = new StringBuilder(50);

            foreach (string one in images)
                builder.Append(one);

            return builder.ToString();
        }
        public static IEnumerable<string> StringToImages(string images)
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
