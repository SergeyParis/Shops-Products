namespace ShopProducts.SDK
{
    public interface ISingleItem
    {
        long Id { get; set; }
        string Title { get; set; }
        string GalleryUrl { get; set; }
        string Url { get; set; }

        string Location { get; set; }
        string Country { get; set; }

        string CurrencyName { get; set; }
        decimal Price { get; set; }
    }
}
