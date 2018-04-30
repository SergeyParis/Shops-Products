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
    }
}
