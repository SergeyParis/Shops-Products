using System.Web.Mvc;

namespace ShopsProducts.Web.Controllers
{
    public class ShopsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EBay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EBay(string query)
        {
            return View();
        }
    }
}