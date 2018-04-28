namespace ShopsProducts.Data
{
    public static class IDetailsSingleItemExtensions
    {
        public static DetailsSingleItemWrapped ToWrapped(this SDK.IDetailsSingleItem one)
            => new DetailsSingleItemWrapped(one.SingleItem, one.ImagesUrl);
    }
}
