using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WaterConservation.BusinessLogic;
using WaterConservation.Entities;

namespace WaterConservation.Controllers
{
    public class PredictionController : Controller
    {
        WaterPredictionManager waterPredictionManager = new WaterPredictionManager();
        // GET: Prediction
        public ActionResult Index()
        {
            var data = waterPredictionManager.GetWaterPredictionData();
            var result = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(data);
            DataTable resultDT = waterPredictionManager.ToDataTable(result);
            List<WaterPredictionModel> obj = waterPredictionManager.ConvertDatatableToList(resultDT);
            Session["CompleteResultList"] = obj;
            ViewBag.States = waterPredictionManager.PopulateStates(obj);
            return View();
        }

        [HttpGet]
        public ActionResult GetDistricts(string state)
        {
            List<WaterPredictionModel> dataSet = Session["CompleteResultList"] as List<WaterPredictionModel>;
            var disctricts = dataSet.Where(stateitem => stateitem.NameOfState.Equals(state)).ToList().Select(district => district.NameOfDistrict).ToList();
            disctricts.Sort();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var resultJson = Json(serializer.Serialize(disctricts), JsonRequestBehavior.AllowGet);
            return resultJson;
        }

        [HttpGet]
        public ActionResult LoadDistrictWiseGroundWaterRecharge(string state)
        {
            List<WaterPredictionModel> dataSet = Session["CompleteResultList"] as List<WaterPredictionModel>;
            var disctricts = dataSet.Where(stateitem => stateitem.NameOfState.Equals(state)).ToList();
            DistrictWiseGroundWaterPresentationModel obj = new DistrictWiseGroundWaterPresentationModel();
            foreach(var districtItem in disctricts)
            {
                obj.AllDistrictsStateQuantity.Add(new TotalGroundWaterPresentationEntity(districtItem.NameOfDistrict, districtItem.TotalAnnualGroundWaterRecharge));
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var resultJson = Json(serializer.Serialize(obj.AllDistrictsStateQuantity), JsonRequestBehavior.AllowGet);
            return resultJson;
        }


        [HttpGet]
        public ActionResult LoadDistrictWiseGroundWaterExtraction(string state)
        {
            List<WaterPredictionModel> dataSet = Session["CompleteResultList"] as List<WaterPredictionModel>;
            var disctricts = dataSet.Where(stateitem => stateitem.NameOfState.Equals(state)).ToList();
            DistrictWiseGroundWaterPresentationModel obj = new DistrictWiseGroundWaterPresentationModel();

            foreach (var districtItem in disctricts)
            {
                obj.AllDistrictsStateQuantity.Add(new TotalGroundWaterPresentationEntity(districtItem.NameOfDistrict, districtItem.TotalCurrentAnnualGroundWaterExtraction));
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var resultJson = Json(serializer.Serialize(obj.AllDistrictsStateQuantity), JsonRequestBehavior.AllowGet);
            return resultJson;
        }

        [HttpGet]
        public ActionResult GetCountryGroundWaterAvailabilityForFutureUse()
        {
            List<WaterPredictionModel> dataSet = Session["CompleteResultList"] as List<WaterPredictionModel>;
            
            var storageForFuture = dataSet.GroupBy(st => st.NameOfState)
                .Select(x => new {
                    NameOfState = x.First().NameOfState,
                    NetGroundWaterAvailabilityForFutureUse = x.Sum(xt => xt.NetGroundWaterAvailabilityForFutureUse.HasValue ? 
                    (double?)Math.Round(xt.NetGroundWaterAvailabilityForFutureUse.Value) : 0)
                }).ToList();
            double? totalStorageForCountry = 0;
            foreach (var stateGroundWaterAvailabilityForFutureUse in storageForFuture)
            {
                totalStorageForCountry += stateGroundWaterAvailabilityForFutureUse.NetGroundWaterAvailabilityForFutureUse;
            }

            PredictionManager predictionManager = new PredictionManager();
            List<AvarageYearlyCountryStorage> resultList = predictionManager.GetYearlyStorage(totalStorageForCountry, storageForFuture.Count);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var resultJson = Json(serializer.Serialize(resultList), JsonRequestBehavior.AllowGet);
            return resultJson;
        }

    }
}