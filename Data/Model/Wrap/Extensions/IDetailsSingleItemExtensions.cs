using ShopsProducts.SDK;
using ShopsProducts.SDK.eBay;
using System.Linq;

namespace ShopsProducts.Data
{
    public static class IDetailsSingleItemExtensions
    {
        public static DetailsSingleItemWrapped Wrapped(this SDK.IDetailsSingleItem one)
        {
            if (one == null || one.ImagesUrl == null)
                return new DetailsSingleItemWrapped(new string[0]);
            if (one.ImagesUrl.Count() > 0)
                return new DetailsSingleItemWrapped(one.ImagesUrl);

            return new DetailsSingleItemWrapped();
        }

        public static EBayDetailsSingleItem UnWrappedToEbay(this DetailsSingleItemWrapped one) => new EBayDetailsSingleItem(one.ImagesUrl);
    }
}
