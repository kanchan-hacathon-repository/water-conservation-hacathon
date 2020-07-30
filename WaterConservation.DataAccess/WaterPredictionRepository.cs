using System.Net;

namespace WaterConservation.DataAccess
{
    public class WaterPredictionRepository
    {
        public HttpWebResponse GetWaterPredictionData()
        {
            // httpWebRequest with API URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create
            ($"https://storagestatistics.eu-gb.mybluemix.net/api/GroundWaterStats/GetJsonValue");

            //Method GET
            request.Method = "GET";

            //HttpWebResponse for result
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
    }
}
