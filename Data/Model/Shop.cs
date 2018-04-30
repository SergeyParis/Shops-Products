using System.Collections.Generic;

namespace ShopsProducts.Data
{
    public class Shop
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<SearchResultsWrapped> SearchResults { get; set; }

        internal Shop() : this("") { }
        public Shop(string name)
        {
            Name = name;
            SearchResults = new List<SearchResultsWrapped>();
        }
    }
}
