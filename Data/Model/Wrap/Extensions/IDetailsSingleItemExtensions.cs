namespace ShopsProducts.Data
{
    public static class IDetailsSingleItemExtensions
    {
        public static DetailsSingleItemWrapped ToWrapped(this SDK.IDetailsSingleItem one, SingleItemWrapped single)
            => new DetailsSingleItemWrapped(one.Id, one.ImagesUrl) { SingleItem = single };
    }
}
