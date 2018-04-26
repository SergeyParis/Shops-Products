namespace ShopsProducts.SDK.eBay
{
    internal class EBaySingleItem : ISingleItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string GalleryUrl { get; set; }
        public string Url { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }

        public EBaySingleItem() { }
        public EBaySingleItem(long id, string title, string galleryURL, string url, string country, decimal price)
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
