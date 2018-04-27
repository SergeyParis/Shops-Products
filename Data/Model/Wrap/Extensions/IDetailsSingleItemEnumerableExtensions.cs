using System.Collections.Generic;

namespace ShopsProducts.Data
{
    public static class IDetailsSingleItemEnumerableExtensions
    {
        public static IEnumerable<DetailsSingleItemWrapped> ToWrapped(this IEnumerable<SDK.IDetailsSingleItem> collection, IEnumerable<SingleItemWrapped> singleCollection)
        {
            IEnumerator<SDK.IDetailsSingleItem> enumerator = collection.GetEnumerator();
            IEnumerator<SingleItemWrapped> singleEnumerator = singleCollection.GetEnumerator();

            int length = 0;
            while (enumerator.MoveNext())
                length++;

            DetailsSingleItemWrapped[] array = new DetailsSingleItemWrapped[length];

            int i = 0;
            while (enumerator.MoveNext() && singleEnumerator.MoveNext())
                array[i++] = enumerator.Current.ToWrapped(singleEnumerator.Current);

            return array;
        }
    }
}
