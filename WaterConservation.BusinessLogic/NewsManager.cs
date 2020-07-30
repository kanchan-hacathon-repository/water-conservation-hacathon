using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WaterConservation.DataAccess;
using WaterConservation.Entities;

namespace WaterConservation.BusinessLogic
{
    public class NewsManager
    {
        NewsRepository newsRepository = new NewsRepository();
        public List<NewsItem> GetNewsContent(string NewsParameters)
        {

            List<NewsItem> news = new List<NewsItem>();

            HttpWebResponse response = newsRepository.GetGoogleNewsData(NewsParameters);

            //Mapping of status code
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == "")
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                //Get news data in json string

                string data = readStream.ReadToEnd();

                //Declare DataSet for putting data in it.
                DataSet ds = new DataSet();
                StringReader reader = new StringReader(data);
                ds.ReadXml(reader);
                DataTable dtGetNews = new DataTable();

                if (ds.Tables.Count > 3)
                {
                    dtGetNews = ds.Tables["item"];

                    foreach (DataRow dtRow in dtGetNews.Rows)
                    {
                        NewsItem DataObj = new NewsItem
                        {
                            Title = dtRow["title"].ToString(),
                            Link = dtRow["link"].ToString(),
                            Item_id = dtRow["item_id"].ToString(),
                            PubDate = dtRow["pubDate"].ToString(),
                            Description = dtRow["description"].ToString()
                        };
                        news.Add(DataObj);
                    }
                }
            }
            return news.OrderByDescending(date => Convert.ToDateTime(date.PubDate)).ToList();
        }

        
    }
}
