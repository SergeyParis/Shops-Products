using System.Collections.Generic;
using System.Linq;

namespace ShopsProducts.Data
{
    public static class IDetailsSingleItemEnumerableExtensions
    {
        public static IEnumerable<DetailsSingleItemWrapped> ToWrapped(this IEnumerable<SDK.IDetailsSingleItem> collection)
        {
            IEnumerator<SDK.IDetailsSingleItem> enumerator = collection.GetEnumerator();

            int length = 0;
            while (enumerator.MoveNext())
                length++;

            DetailsSingleItemWrapped[] array = new DetailsSingleItemWrapped[length];

            int i = 0;
            while (enumerator.MoveNext())
                array[i++] = enumerator.Current.ToWrapped();

            return array;
        }
    }
}
