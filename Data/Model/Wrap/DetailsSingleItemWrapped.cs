using System.Collections.Generic;
using ShopsProducts.SDK;

namespace ShopsProducts.Data
{
    public sealed class DetailsSingleItemWrapped : IDetailsSingleItem
    {
        public long Id { get; set; }
        public SingleItemWrapped SingleItemWrapped { get; set; }

        public IEnumerable<string> ImagesUrl { get; set; }

        internal string ImagesUrlString { get; set; }

        internal DetailsSingleItemWrapped() { }
        public DetailsSingleItemWrapped(IEnumerable<string> images)
        {
            ImagesUrl = images;
            ImagesUrlString = ImagesUrl.ImagesToString();
        }
    }
}
