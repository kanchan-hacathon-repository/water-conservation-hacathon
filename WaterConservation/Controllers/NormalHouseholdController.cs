using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WaterConservation.BusinessLogic;
using WaterConservation.Entities;

namespace WaterConservation.Controllers
{
    public class NormalHouseholdController : Controller
    {
        // GET: NormalHousehold
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadHouseholdHarvestChart(string catchmentArea, string rainfall, string efficiency, string collectionPoints)
        {
            decimal numArea = Convert.ToDecimal(catchmentArea);
            decimal numRainFall = Convert.ToDecimal(rainfall);
            decimal numEfficiency = Convert.ToDecimal(efficiency);
            decimal numCollectionPoints = Convert.ToDecimal(collectionPoints);
            RainHarvestCalculator calc = new RainHarvestCalculator();
            List<HarvestResultEntity> result = calc.HarvestChartCalculator(numArea, numRainFall, numEfficiency, numCollectionPoints);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var resultJson = Json(serializer.Serialize(result), JsonRequestBehavior.AllowGet);
            return resultJson;
        }

        [HttpPost]
        public decimal HarvestCalculator(string catchmentArea, string rainfall, string efficiency, string collectionPoints)
        {
            decimal numArea = Convert.ToDecimal(catchmentArea);
            decimal numRainFall = Convert.ToDecimal(rainfall);
            decimal numEfficiency = Convert.ToDecimal(efficiency);
            decimal numCollectionPoints = Convert.ToDecimal(collectionPoints);
            RainHarvestCalculator calc = new RainHarvestCalculator();

            decimal totalHarvest = calc.CalculateHarvest(numArea, numRainFall, numEfficiency, numCollectionPoints);

            return totalHarvest;
        }
    }
}