using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShopsProducts.SDK.eBay
{
    class EBayDetailsSingleItem : IDetailsSingleItem
    {
        public ISingleItem SingleItem { get; set; }
        public IEnumerable<string> ImagesUrl { get; set; }

        public EBayDetailsSingleItem(ISingleItem item) : this(item, null) { }
        public EBayDetailsSingleItem(ISingleItem item, IEnumerable<string> images)
        {
            SingleItem = item;
            ImagesUrl = images;
        }
    }
}
