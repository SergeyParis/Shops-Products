using System.Collections.Generic;

namespace ShopsProducts.Data
{
    public sealed class SingleItemWrapped : SDK.ISingleItem
    {
        internal int DataBaseId { get; set; }

        public long Id { get; set; }
        public string Title { get; set; }
        public string GalleryUrl { get; set; }
        public string Url { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string CurrencyName { get; set; }
        public decimal Price { get; set; }

        internal SingleItemWrapped() { }
        public SingleItemWrapped(long id, string title, string galleryURL, string url, string location, string country, string currencyName, decimal price)
        {
            Id = id;
            Title = title;
            GalleryUrl = galleryURL;
            Url = url;
            Location = location;
            Country = country;
            CurrencyName = currencyName;
            Price = price;
        }

        public static IEnumerable<SingleItemWrapped> ToWrapped(IEnumerable<SDK.ISingleItem> collection)
        {
            IEnumerator<SDK.ISingleItem> enumerator = collection.GetEnumerator();

            int length = 0;
            while (enumerator.MoveNext())
                length++;

            SingleItemWrapped[] array = new SingleItemWrapped[length];

            int i = 0;
            foreach (var one in collection)
                array[i++] = ToWrapped(one);

            return array;
        }
        public static SingleItemWrapped ToWrapped(SDK.ISingleItem one) 
            => new SingleItemWrapped(one.Id, one.Title, one.GalleryUrl, one.Url, one.Location, one.Country, one.CurrencyName, one.Price);
    }
}
