namespace ShopsProducts.SDK
{
    public interface ISingleItem
    {
        long ItemId { get; set; }
        string Title { get; set; }
        string GalleryUrl { get; set; }
        string Url { get; set; }
        
        string Country { get; set; }
        
        decimal Price { get; set; }

        IDetailsSingleItem Details { get; set; }
    }
}
