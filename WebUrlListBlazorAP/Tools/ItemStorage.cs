using LiteDB;
using System;
using WebUrlListBlazorAP.Data;

namespace WebUrlListBlazorAP.Tools
{
    public class ItemStorage
    {
        private LiteDatabase _db;
        private static ItemStorage? _instance = null;
        public static ItemStorage Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ItemStorage();
                }
                return _instance;
            } 
        }

        private ItemStorage()
        {
            string path = @"MyData.db";
            _db = new LiteDatabase(path);
        }

        public static List<WebUrlData> LoadDatas() 
        {
            List<WebUrlData> list = new List<WebUrlData>();

            string path = @"MyData.db";
            var db = new LiteDatabase(path);
            var col = db.GetCollection<WebUrlData>("weburl");
            list = col.FindAll().ToList();

            return list;
        }

        public void Add(WebUrlData data)
        {
            var col = _db.GetCollection<WebUrlData>("weburl");
            var ret = col.Insert(data);
            _db.Commit();
        }

        public void Delete(string name) 
        {
            var col = _db.GetCollection<WebUrlData>("weburl");
            col.Delete(name);
            _db.Commit();
        }

        public List<WebUrlData> ListAll()
        {
            var col = _db.GetCollection<WebUrlData>("weburl");
            var list = col.FindAll();
            return list.ToList();
        }

        public WebUrlData? GetByName(string name)
        {
            var col = _db.GetCollection<WebUrlData>("weburl");
            WebUrlData? data = null;
            var query = col.Query().Where(u => u.Name == name).ToEnumerable();
            //Person u = col.Query().Where(x => x.Name == "20b1e07a-4182-41ae-af76-27dc3e2742a4").First();
            //u.Age = 33;
            //col.Update(u);
            data = query.FirstOrDefault();
            return data;
        }
    }
}
