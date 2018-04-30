namespace ShopsProducts.SDK.eBay
{
    public class EBaySingleItem : ISingleItem
    {
        public long ItemId { get; set; }
        public string Title { get; set; }
        public string GalleryUrl { get; set; }
        public string Url { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public IDetailsSingleItem Details { get; set; }

        public EBaySingleItem() { }
        public EBaySingleItem(long id, string title, string galleryURL, string url, string country, decimal price)
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
