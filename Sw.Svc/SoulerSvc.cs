using Sw.Base.Entity;
using Sw.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Svc
{
    public class SoulerSvc
    {
        public List<Souler> GetPage(int page,int length)
        {
            var q = LiteDB.Query.All("AddTime", -1);
            var list = LDO<Souler>.GetPage(q,page , length);
            return list;
        }

        public int Add(Souler souler)
        {
            return LDO<Souler>.Add(souler);
        }


        public Souler Get(string id)
        {
            return LDO<Souler>.Get(id);
        }
    }
}
