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
            IEnumerable<ISingleItem> items = await EBayAPI.GetProducts(query);
            IEnumerable<SingleItemWrapped> itemsWrapped = SingleItemWrapped.ToWrapped(items);

            Query q = new Query(query) { Results = itemsWrapped };

            // context.Shops.Where(s => s.Name == "eBay").First().Queries.Add(q);
            // context.SaveChangesAsync();

            ViewBag.items = items.ToArray();

            return View();
        }

        [HttpGet]
        public ActionResult EbayItem(long id)
        {
            return View();
        }
    }
}