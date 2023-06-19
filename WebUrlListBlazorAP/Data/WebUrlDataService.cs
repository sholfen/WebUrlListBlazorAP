using System.Collections.Concurrent;

namespace WebUrlListBlazorAP.Data
{
    public class WebUrlDataService
    {
        private static ConcurrentBag<WebUrlData> _list = new ConcurrentBag<WebUrlData>
        {
             new WebUrlData
             {
                 Name = "명아츄 ASMR Irene",
                 Url = "https://www.youtube.com/@auddkasmr/videos"
             },
             new WebUrlData
             {
                 Name = "砲姐影片",
                 Url = "https://www.youtube.com/watch?v=PhRa36fkNs8"
             }
        };

        public WebUrlDataService() 
        {

        }

        public void Insert(string name, string url)
        {
            WebUrlData data = new WebUrlData
            {
                Created = DateTime.Now,
                Name = name,
                Url = url
            };
            _list.Add(data);
        }

        public List<WebUrlData> GetList() 
        {
            return _list.ToList();
        }
    }
}
