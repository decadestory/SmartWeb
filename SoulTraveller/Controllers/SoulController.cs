using Sw.Base.Entity;
using Sw.Svc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoulTraveller.Controllers
{
    public class SoulController : Controller
    {
        SoulerSvc svc = new SoulerSvc();

        // GET: Soul
        public ActionResult Index()
        {
            var list = svc.GetPage(1, 4);
            return View(list);
        }

        [HttpPost]
        public ActionResult GetPage(int page,int len=4) 
        {
            var res = svc.GetPage(page, len);
            return Json(res);
        }

        public ActionResult Detail(int id = 5)
        {
            var detail = svc.Get(id);
            return View(detail);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Souler souler)
        {
            if (string.IsNullOrEmpty(souler.Summary)) souler.Summary = "天总会黑，天黑前能明白就好。 - 心灵旅客";
            if (string.IsNullOrEmpty(souler.Title)) souler.Title = "未命题";
            souler.Comment = 0;
            souler.Views = 0;
            souler.Applaud = 0;
            souler.Shared = 0;
            souler.AddTime = DateTime.Now;
            souler.Enable = true;
            var res = svc.Add(souler);
            if (res > 0) return Json(new { res = "添加成功" });
            return Json(new { data = "添加失败" });
        }

        [HttpPost]
        public ActionResult Upload()
        {
            var file = HttpContext.Request.Files.Get("uploader");

            if (file.ContentLength > 2 * 1024 * 1024)
                return Json(new { url = -1 });

            //图片保存的文件夹路径
            string path = AppDomain.CurrentDomain.BaseDirectory + "Images/";
            //每天上传的图片一个文件夹
            string folder = DateTime.Now.ToString("yyyy-MM-dd");
            //如果文件夹不存在，则创建
            if (!Directory.Exists(path + folder)) Directory.CreateDirectory(path + folder);
            //上传图片的扩展名
            string type = file.FileName.Substring(file.FileName.LastIndexOf('.'));

            if (!new[] { ".jpg", ".png", ".gif" }.Contains(type.ToLower()))
                return Json(new { url = -2 });

            //保存图片的文件名
            string saveName = Guid.NewGuid().ToString() + type;
            //保存图片
            file.SaveAs(path + folder + "/" + saveName);
            var dbname = folder + "/" + saveName;

            return Json(new { url = dbname });
        }


    }
}