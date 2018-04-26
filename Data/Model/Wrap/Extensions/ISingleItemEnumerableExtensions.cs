using System.Collections.Generic;

namespace ShopsProducts.Data
{
    public static class ISingleItemEnumerableExtensions
    {
        public static IEnumerable<SingleItemWrapped> ToWrapped(this IEnumerable<SDK.ISingleItem> collection)
        {
            IEnumerator<SDK.ISingleItem> enumerator = collection.GetEnumerator();

            int length = 0;
            while (enumerator.MoveNext())
                length++;

            SingleItemWrapped[] array = new SingleItemWrapped[length];

            int i = 0;
            foreach (SDK.ISingleItem one in collection)
                array[i++] = one.ToWrapped();

            return array;
        }
    }
}
