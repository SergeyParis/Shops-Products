using System.Collections.Generic;
using System.Linq;
using ShopsProducts.SDK.eBay;
using ShopsProducts.SDK;

namespace ShopsProducts.Data
{
    public static class ISingleItemEnumerableExtensions
    {
        public static IEnumerable<SingleItemWrapped> Wrapped(this IEnumerable<ISingleItem> collection)
        {
            if (collection == null)
                return null;

            SingleItemWrapped[] c = new SingleItemWrapped[collection.Count()];

            int i = 0;
            foreach (var one in collection)
                if (one != null)
                    c[i++] = one.Wrapped();
                else
                    c[i++] = null;

            return c;
        }
        public static IEnumerable<EBaySingleItem> UnWrappedToEbay(this IEnumerable<SingleItemWrapped> collection) => collection.Select(it => it.UnWrappedToEbay());
    }
}
