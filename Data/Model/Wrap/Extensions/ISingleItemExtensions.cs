using ShopsProducts.SDK.eBay;
using ShopsProducts.SDK;

namespace ShopsProducts.Data
{
    public static class ISingleItemExtensions
    {
        public static SingleItemWrapped Wrapped(this ISingleItem one)
            => new SingleItemWrapped(one.ItemId, one.Title, one.GalleryUrl, one.Url, one.Country, one.Price) { Details = one.Details, DetailsWrapped = one.Details.Wrapped() };
        public static EBaySingleItem UnWrappedToEbay(this SingleItemWrapped one)
            => new EBaySingleItem(one.ItemId, one.Title, one.GalleryUrl, one.Url, one.Country, one.Price);
    }
}
