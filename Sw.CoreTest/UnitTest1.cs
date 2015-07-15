using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sw.Base.Entity;
using Sw.Core;
using Sw.Base.Enum;

namespace Sw.CoreTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            for (int i = 1; i <= 1; i++)
            {
                var st = new Souler
                {
                    Title = "铁达尼号纯节奏",
                    Img = "Images/" + i + ".jpg",
                    Audio = "http://m6.songtaste.com/201507121623/0bd9ab34c611757e56da6a10607c9b49/6/60/60dad63d6ff68646e20031305dc85abd.mp3",
                    Summary = "Heart of the Ocean [Radio Mix] -- Mythos 'N DJ Cosmo, 用音乐雷达搜到的，www.doreso.cn",
                    Comment = i,
                    Views = i,
                    Applaud = i,
                    Shared = i,
                    Enable = true,
                    Colors = "#233222",
                    AddTime = DateTime.Now,
                    ShowType = (int)ShowType.SetDefault
                };
                var result = LDO<Souler>.Add(st);
                //var result2 = LDO<Souler>.Delete(i);
            }


            //var one = LDO<Souler>.Get(5008);

            var q = LiteDB.Query.All("AddTime",-1);
            var list = LDO<Souler>.GetPage(q,2,5);

            Assert.IsTrue(1==1);
        }
    }
}
