using Sw.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Core
{
    public class LDO<T> where T : new()
    {
        private static string dbpath;
        private static LiteDB.LiteDatabase db;

        static LDO()
        {
            dbpath = AppDomain.CurrentDomain.BaseDirectory + "/Stores/data.db";
            db = new LiteDB.LiteDatabase(dbpath);
        }

        public static LiteDB.LiteCollection<T> GetCol()
        {
            var className = typeof(T).Name;
            return db.GetCollection<T>(className);
        }

        public static int Add(T entity)
        {
            var col = GetCol();
            return col.Insert(entity);
        }

        public static bool Delete(int id)
        {
            var col = GetCol();
            return col.Delete(id);
        }

        public static bool Update(T entity)
        {
            var col = GetCol();
            return col.Update(entity);
        }


        public static T Get(string id)
        {
            var col = GetCol();
            return col.FindById(id);
        }

        public static List<T> GetPage(LiteDB.Query query,int page,int length)
        {
            var col = GetCol();
            return col.Find(query,(page-1)*length,length).ToList<T>();
        }

    }
}


