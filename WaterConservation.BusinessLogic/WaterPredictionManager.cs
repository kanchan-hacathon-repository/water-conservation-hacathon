using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WaterConservation.DataAccess;
using WaterConservation.Entities;
using System.Web.Mvc;

namespace WaterConservation.BusinessLogic
{
    public class WaterPredictionManager
    {
        WaterPredictionRepository waterPredictionRepository = new WaterPredictionRepository();
        public string GetWaterPredictionData()
        {
            string returnData = string.Empty;
            try
            {
                HttpWebResponse response = waterPredictionRepository.GetWaterPredictionData();

                //Mapping of status code
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == "")
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    returnData = readStream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
            }
            return returnData;
        }

        public List<SelectListItem> PopulateStates(List<WaterPredictionModel> obj)
        {
            var States = obj.GroupBy(p => p.NameOfState).Select(g => g.First()).Select(n => n.NameOfState).ToList();
            States.Sort();
            return States.Select(r => new SelectListItem { Text = r, Value = r }).ToList();
        }

        public List<WaterPredictionModel> ConvertDatatableToList(DataTable resultDT)
        {
            WaterPredictionContainerModel resultModel = new WaterPredictionContainerModel();
            foreach (DataRow row in resultDT.Rows)
            {
                long sNo = Convert.ToInt32(row["S#no#"].ToString());
                string NameOfState = Convert.ToString(row["Name of State"]);
                string NameOfDistrict = Convert.ToString(row["Name of District"]);
                double? RechargeFromRainfallDuringMonsoonSeason = Convert.ToDouble((row["Recharge from rainfall During Monsoon Season"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Recharge from rainfall During Monsoon Season"]));
                double? RechargeFromOtherSourcesDuringMonsoonSeason = Convert.ToDouble((row["Recharge from other sources During Monsoon Season"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Recharge from other sources During Monsoon Season"]));
                double? RechargeFromRainfallDuringNonMonsoonSeason = Convert.ToDouble((row["Recharge from rainfall During Non Monsoon Season"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Recharge from rainfall During Non Monsoon Season"]));
                double? RechargeFromOtherSourcesDuringNonMonsoonSeason = Convert.ToDouble((row["Recharge from other sources During Non Monsoon Season"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Recharge from other sources During Non Monsoon Season"]));


                double? TotalAnnualGroundWaterRecharge = Convert.ToDouble((row["Total Annual Ground Water Recharge"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Total Annual Ground Water Recharge"]));
                double? TotalNaturalDischarges = Convert.ToDouble((row["Total Natural Discharges"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Total Natural Discharges"]));
                double? AnnualExtractableGroundWaterResource = Convert.ToDouble((row["Annual Extractable Ground Water Resource"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Annual Extractable Ground Water Resource"]));
                double? CurrentAnnualGroundWaterExtractionForIrrigation = Convert.ToDouble((row["Current Annual Ground Water Extraction For Irrigation"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Current Annual Ground Water Extraction For Irrigation"]));

                double CurrentAnnualGroundWaterExtractionForDomesticIndustrial = Convert.ToDouble(row["Current Annual Ground Water Extraction For Domestic & Industrial"]);
                double? TotalCurrentAnnualGroundWaterExtraction = Convert.ToDouble((row["Total Current Annual Ground Water Extraction"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Total Current Annual Ground Water Extraction"]));
                double? AnnualGwAllocationForDomesticUseAsOn2025 = Convert.ToDouble((row["Annual GW Allocation for Domestic Use as on 2025"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Annual GW Allocation for Domestic Use as on 2025"]));
                double? NetGroundWaterAvailabilityForFutureUse = Convert.ToDouble((row["Net Ground Water Availability for future use"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Net Ground Water Availability for future use"]));
                double? StageOfGroundWaterExtraction = Convert.ToDouble((row["Stage of Ground Water Extraction (%)"].GetType().Name.Equals("DBNull")
                    ? 0 : row["Stage of Ground Water Extraction (%)"]));

                resultModel.predictionModel.Add(new WaterPredictionModel(sNo, NameOfState, NameOfDistrict, RechargeFromRainfallDuringMonsoonSeason,
                        RechargeFromOtherSourcesDuringMonsoonSeason, RechargeFromRainfallDuringNonMonsoonSeason, RechargeFromOtherSourcesDuringNonMonsoonSeason,
                        TotalAnnualGroundWaterRecharge, TotalNaturalDischarges, AnnualExtractableGroundWaterResource, CurrentAnnualGroundWaterExtractionForIrrigation,
                        CurrentAnnualGroundWaterExtractionForDomesticIndustrial, TotalCurrentAnnualGroundWaterExtraction, AnnualGwAllocationForDomesticUseAsOn2025,
                        NetGroundWaterAvailabilityForFutureUse, StageOfGroundWaterExtraction));
            }
            return resultModel.predictionModel;
        }

        public DataTable ToDataTable(List<Dictionary<string, string>> list)
        {
            DataTable result = new DataTable();
            if (list.Count == 0)
                return result;

            var columnNames = list.SelectMany(dict => dict.Keys).Distinct();
            result.Columns.AddRange(columnNames.Select(c => new DataColumn(c)).ToArray());
            foreach (Dictionary<string, string> item in list)
            {
                var row = result.NewRow();
                foreach (var key in item.Keys)
                {
                    row[key] = item[key];
                }

                result.Rows.Add(row);
            }

            return result;
        }
    }
}
