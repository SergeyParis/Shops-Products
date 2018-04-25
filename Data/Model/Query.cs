using System.Collections.Generic;

namespace ShopProducts.Data
{
    public class Query
    {
        internal int Id { get; set; }
        public string Text { get; set; }

        public IEnumerable<SingleItemWrapped> Results { get; set; }
    }
}
