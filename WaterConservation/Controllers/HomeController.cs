using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WaterConservation.BusinessLogic;

namespace WaterConservation.Controllers
{
    public class HomeController : Controller
    {
        private GreetingsManager manager = new GreetingsManager();
        private NewsManager newsManager = new NewsManager();
        public ActionResult Index()
        {
            ViewBag.NewsItems = newsManager.GetNewsContent("waterconservation").Take(10);
            return View();
        }

        [HttpGet]
        public ActionResult GetGreetingMessage(string currentTime)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var resultJson = Json(serializer.Serialize(manager.GetGreetingMessage(currentTime).GreetingMessage), JsonRequestBehavior.AllowGet);
            return resultJson;
        }
    }
}