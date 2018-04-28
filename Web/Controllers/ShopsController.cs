using System.Web.Mvc;
using ShopsProducts.SDK;
using ShopsProducts.SDK.eBay;
using ShopsProducts.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ShopsController : Controller
    {
        private static ShopsProductsContext context = new ShopsProductsContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EBay()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EBay(string query)
        {
            SearchResults searchResults = await EBayAPI.GetProducts(query);
            IEnumerable<ISingleItem> items = searchResults.Results;
            IEnumerable<IDetailsSingleItem> itemsDetails = await EBayAPI.GetProductsDetail(items);

            SearchResultsWrapped resultsWrapped = new SearchResultsWrapped(searchResults);
            
            // context.Shops.Where(s => s.Name == "eBay").First().Queries.Add(q);
            // context.SaveChangesAsync();
            
            return View(items);
        }

        [HttpGet]
        public ActionResult EbayItem(long id)
        {
            IEnumerable<IDetailsSingleItem> items = (IEnumerable<IDetailsSingleItem>)ViewBag.itemsDetails;
            IDetailsSingleItem detailsItem = items.Where(it => it.SingleItem.Id == id).First();
            
            return View(detailsItem);
        }
    }
}