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
    }
}
