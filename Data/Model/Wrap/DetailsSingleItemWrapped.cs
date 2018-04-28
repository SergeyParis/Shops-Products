using System.Collections.Generic;
using ShopsProducts.SDK;

namespace ShopsProducts.Data
{
    public sealed class DetailsSingleItemWrapped : IDetailsSingleItem
    {
        public SingleItemWrapped SingleItemWrapped => SingleItem.ToWrapped();
        public ISingleItem SingleItem { get; set; }
        
        public IEnumerable<string> ImagesUrl { get; set; }

        internal string ImagesUrlString => ImagesUrl.ImagesToString();

        internal DetailsSingleItemWrapped() { }
        public DetailsSingleItemWrapped(ISingleItem item) : this(item, null) { }
        public DetailsSingleItemWrapped(ISingleItem item, IEnumerable<string> images)
        {
            SingleItem = item;
            ImagesUrl = images;
        }
    }
}
