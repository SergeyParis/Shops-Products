using System.Collections.Generic;

namespace ShopsProducts.Data
{
    public class Query
    {
        internal int Id { get; set; }
        public string Text { get; set; }

        public IEnumerable<SingleItemWrapped> Results { get; set; }

        internal Query() { }
        public Query(string text) { Text = text; }
    }
}
