using System.Net;

namespace WaterConservation.DataAccess
{
    public class NewsRepository
    {
        public HttpWebResponse GetGoogleNewsData(string NewsParameters)
        {
            // httpWebRequest with API URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create
            ($"http://news.google.co.in/news?q={NewsParameters}&output=rss");

            //Method GET
            request.Method = "GET";

            //HttpWebResponse for result
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
    }
}
