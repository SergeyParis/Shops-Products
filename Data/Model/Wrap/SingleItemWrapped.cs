using System.Collections.Generic;

namespace ShopsProducts.Data
{
    public sealed class SingleItemWrapped : SDK.ISingleItem
    {
        internal int DataBaseId { get; set; }

        public long Id { get; set; }
        public string Title { get; set; }
        public string GalleryUrl { get; set; }
        public string Url { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }

        internal SingleItemWrapped() { }
        public SingleItemWrapped(long id, string title, string galleryURL, string url, string country, decimal price)
        {
            Id = id;
            Title = title;
            GalleryUrl = galleryURL;
            Url = url;
            Country = country;
            Price = price;
        }
    }
}
