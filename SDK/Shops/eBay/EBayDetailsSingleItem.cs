using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShopsProducts.SDK.eBay
{
    public class EBayDetailsSingleItem : IDetailsSingleItem
    {
        public IEnumerable<string> ImagesUrl { get; set; }

        public EBayDetailsSingleItem() : this(null) { }
        public EBayDetailsSingleItem(IEnumerable<string> images)
        {
            ImagesUrl = images;
        }

        public override bool Equals(object obj)
        {
            EBayDetailsSingleItem item = obj as EBayDetailsSingleItem;

            string[] thisArray = ImagesUrl.ToArray();
            string[] compareArray = item.ImagesUrl.ToArray();

            if (thisArray.Length != compareArray.Length)
                return false;

            if (item != null)
            {
                for (int i = 0; i < thisArray.Length; i++)
                    if (thisArray[i] != compareArray[i])
                        return false;

                return true;
            }
            else
                return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
