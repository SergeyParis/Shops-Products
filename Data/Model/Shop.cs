using System.Collections.Generic;

namespace ShopProducts.Data
{
    internal sealed class Shop
    {
        internal int Id { get; set; }
        
        public string Name { get; set; }
        public IEnumerable<SingleItemWrapped> Items { get; set; }

        public Shop(string name)
        {
            Name = name;
        }
    }
}
