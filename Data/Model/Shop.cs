using System.Collections.Generic;

namespace ShopsProducts.Data
{
    public class Shop
    {
        internal int Id { get; set; }
        
        public string Name { get; set; }
        public List<Query> Queries { get; set; }

        internal Shop() { }
        public Shop(string name)
        {
            Name = name;
        }
    }
}
