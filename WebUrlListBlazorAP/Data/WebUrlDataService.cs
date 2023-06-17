using System.Collections.Concurrent;

namespace WebUrlListBlazorAP.Data
{
    public class WebUrlDataService
    {
        private static ConcurrentBag<WebUrlData> _list = new ConcurrentBag<WebUrlData>();

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
