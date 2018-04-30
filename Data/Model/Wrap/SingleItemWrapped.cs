using System.Collections.Generic;
using ShopsProducts.SDK;

namespace ShopsProducts.Data
{
    public sealed class SingleItemWrapped : ISingleItem
    {
        public int Id { get; set; }
        public SearchResultsWrapped SearchResultsWrapped { get; set; }

        public long ItemId { get; set; }
        public string Title { get; set; }
        public string GalleryUrl { get; set; }
        public string Url { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public IDetailsSingleItem Details
        {

            get => DetailsWrapped.UnWrappedToEbay();
            set => DetailsWrapped = value.Wrapped();
        }

        public DetailsSingleItemWrapped DetailsWrapped { get; set; }

        internal SingleItemWrapped() { }
        public SingleItemWrapped(long id, string title, string galleryURL, string url, string country, decimal price)
        {
            ItemId = id;
            Title = title;
            GalleryUrl = galleryURL;
            Url = url;
            Country = country;
            Price = price;
        }
    }
}
