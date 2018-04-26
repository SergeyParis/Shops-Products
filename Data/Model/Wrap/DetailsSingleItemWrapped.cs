using System.Collections.Generic;
using ShopsProducts.SDK;

namespace ShopsProducts.Data
{
    public sealed class DetailsSingleItemWrapped : IDetailsSingleItem
    {
        internal SingleItemWrapped SingleItem;

        public long Id { get; set; }
        public IEnumerable<string> ImagesUrl { get; set; }

        internal string ImagesUrlString => ImagesUrl.ImagesToString();

        public DetailsSingleItemWrapped() { }
        public DetailsSingleItemWrapped(long id) : this(id, null) { }
        public DetailsSingleItemWrapped(long id, IEnumerable<string> images)
        {
            Id = id;
            ImagesUrl = images;
        }
    }
}
