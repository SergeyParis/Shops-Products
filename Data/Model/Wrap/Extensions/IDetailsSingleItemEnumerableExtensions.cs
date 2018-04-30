using System.Collections.Generic;
using System.Linq;
using ShopsProducts.SDK;
using ShopsProducts.SDK.eBay;

namespace ShopsProducts.Data
{
    public static class IDetailsSingleItemEnumerableExtensions
    {
        public static IEnumerable<DetailsSingleItemWrapped> Wrapped(this IEnumerable<IDetailsSingleItem> collection) => collection.Select(it => it.Wrapped());
        public static IEnumerable<EBayDetailsSingleItem> UnWrappedToEbay(this IEnumerable<DetailsSingleItemWrapped> collection) => collection.Select(it => it.UnWrappedToEbay());
    }
}
