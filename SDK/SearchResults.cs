using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsProducts.SDK
{
    public class SearchResults
    {
        public string Text { get; set; }
        public int PageIndex { get; set; }

        public IEnumerable<ISingleItem> Results { get; set; }
        
        public SearchResults(string text) : this(text, 1) { }
        public SearchResults(string text, int pageIndex) { Text = text; PageIndex = pageIndex; }
    }
}
