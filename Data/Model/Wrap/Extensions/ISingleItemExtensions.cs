namespace ShopsProducts.Data
{
    public static class ISingleItemExtensions
    {
        public static SingleItemWrapped ToWrapped(this SDK.ISingleItem one)
            => new SingleItemWrapped(one.Id, one.Title, one.GalleryUrl, one.Url, one.Country, one.Price);
    }
}
