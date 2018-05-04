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

        public override bool Equals(object obj)
        {
            return this == obj;
        }
        public override int GetHashCode() => base.GetHashCode();

        public static bool operator ==(EBaySingleItem first, object second)
        {
            if (second is EBaySingleItem)
            {
                EBaySingleItem second2 = (EBaySingleItem)second;

                return first.ItemId == second2.ItemId &&
                       first.Title == second2.Title &&
                       first.GalleryUrl == second2.GalleryUrl &&
                       first.Url == second2.Url &&
                       first.Country == second2.Country &&
                       first.Price == second2.Price;
            }
            else
                return false;
        }
        public static bool operator !=(EBaySingleItem first, object second)
        {
            return !(first == second);
        }
    }
}
