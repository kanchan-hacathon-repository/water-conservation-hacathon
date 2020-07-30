using System.Web.Mvc;

namespace WaterConservation.Controllers
{
    public class FactsController : Controller
    {
        // GET: Facts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WaterBorneDisease()
        {
            return View();
        }
    }
}