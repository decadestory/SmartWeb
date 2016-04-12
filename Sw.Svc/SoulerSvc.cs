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


        public Souler Get(int id)
        {
            return LDO<Souler>.Get(id);
        }

        public int AddApplaud(int id)
        {
            var souler = LDO<Souler>.Get(id);
            souler.Applaud++;
            LDO<Souler>.Update(souler);
            return souler.Applaud;
        }

        public int AddView(int id)
        {
            var souler = LDO<Souler>.Get(id);
            souler.Views++;
            LDO<Souler>.Update(souler);
            return souler.Views;
        }

        public int AddShareTimes(int id)
        {
            var souler = LDO<Souler>.Get(id);
            souler.Shared++;
            LDO<Souler>.Update(souler);
            return souler.Shared;
        }

        public int AddComment(int id)
        {
            var souler = LDO<Souler>.Get(id);
            souler.Comment++;
            LDO<Souler>.Update(souler);
            return souler.Comment;
        }
    }
}
