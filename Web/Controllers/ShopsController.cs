using System.Web.Mvc;
using ShopsProducts.SDK;
using ShopsProducts.SDK.eBay;
using ShopsProducts.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Web.Controllers
{
    public class ShopsController : Controller
    {
        private static ShopsProductsContext context;

        static ShopsController()
        {
            context = new ShopsProductsContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult EBay()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<ActionResult> EBay(string query = "")
        {
            SearchResults results = await GetSearchResults(query);
            return View(results);
        }
        [HttpGet]
        public async Task<ActionResult> EBay(string query = "", int pageIndex = 1)
        {
            SearchResults results = await GetSearchResults(query, pageIndex);
            return View(results);
        }


        [HttpGet]
        public ActionResult EbayItem(long id)
        {
            ISingleItem item = GetSingleItem(id);

            if (item == null)
                return View("Error");
            else
                return View(item);
        }


        [NonAction]
        private ISingleItem GetSingleItem(long id)
        {
            SingleItemWrapped result;
            IEnumerable<SingleItemWrapped> items = context.Items.Where(it => it.ItemId == id);

            if (items.Count() == 0)
                return null;

            result = items.First();

            context.Entry(result).Reference(it => it.DetailsWrapped).Load();

            return result;
        }

        [NonAction]
        private async Task<SearchResults> GetSearchResults(string query, int pageIndex = 1)
        {
            SearchResultsWrapped result;

            IEnumerable<SearchResultsWrapped> cache = context.SearchResults.Where(it => it.Text == query && it.PageIndex == pageIndex);

            if (cache.Count() == 0)
            {
                result = new SearchResultsWrapped(await EBayAPI.GetProductsWithDetails(query, pageIndex));
                CachingSearchResults(result);
            }
            else
            {
                result = cache.First();
                context.Entry(result).Collection(it => it.ResultsWrapped).Load();
            }
            
            result.Results = result.ResultsWrapped.UnWrappedToEbay();

            return result;
        }

        [NonAction]
        private void CachingSearchResults(SearchResults results)
        {
            Shop eBay;
            IEnumerable<Shop> cache = context.Shops.Where(s => s.Name == "eBay");

            if (cache.Count() == 0)
            {
                context.Shops.Add(new Shop("eBay"));
                context.SaveChanges();

                eBay = context.Shops.Where(s => s.Name == "eBay").First();
            }
            else
                eBay = cache.First();

            SearchResultsWrapped resultsWrapped = new SearchResultsWrapped(results);

            resultsWrapped.Shop = eBay;
            resultsWrapped.ResultsWrapped.Select(it => it.SearchResultsWrapped = resultsWrapped);
            resultsWrapped.ResultsWrapped.Select(it => it.DetailsWrapped.SingleItemWrapped = it);

            foreach (var one in resultsWrapped.ResultsWrapped)
                Debug.WriteLine(one.DetailsWrapped);

            eBay.SearchResults.Add(resultsWrapped);

            context.SaveChanges();
        }
    }
}