using System.Collections.Generic;

namespace ShopProducts.Data
{
    public class Shop
    {
        internal int Id { get; set; }
        
        public string Name { get; set; }
        public IEnumerable<Query> Queries { get; set; }

        internal Shop() { }
        public Shop(string name)
        {
            Name = name;
        }
    }
}
