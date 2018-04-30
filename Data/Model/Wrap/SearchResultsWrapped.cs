using System.Collections.Generic;
using ShopsProducts.SDK;
using System.Linq;

namespace ShopsProducts.Data
{
    public class SearchResultsWrapped : SearchResults
    {
        private IEnumerable<ISingleItem> _results;

        public int Id { get; set; }
        public Shop Shop { get; set; }

        override public IEnumerable<ISingleItem> Results
        {
            get => _results;
            set
            {
                _results = value;
                ResultsWrapped = value.Wrapped().ToList();
            }
        }

        public List<SingleItemWrapped> ResultsWrapped { get; set; }

        internal SearchResultsWrapped() : this("") { }
        public SearchResultsWrapped(string text) : this(text, 1) { }
        public SearchResultsWrapped(string text, int pageIndex) : base(text, pageIndex) { }

        public SearchResultsWrapped(SearchResults searchResults) : base(searchResults.Text, searchResults.PageIndex)
        {
            Results = searchResults.Results.Wrapped();
        }

    }
}
