using System.Collections.Generic;

namespace ShopsProducts.Data
{
    public class SearchResultsWrapped : SDK.SearchResults
    {
        internal int Id { get; set; }

        new public IEnumerable<SingleItemWrapped> Results { get; set; }

        internal SearchResultsWrapped() : this("") { }
        public SearchResultsWrapped(string text) : this(text, 1) { }
        public SearchResultsWrapped(string text, int pageIndex) : base(text, pageIndex) { }

        public SearchResultsWrapped(SDK.SearchResults searchResults) : base(searchResults.Text, searchResults.PageIndex)
        {
            Results = searchResults.Results.ToWrapped();
        }
    }
}
