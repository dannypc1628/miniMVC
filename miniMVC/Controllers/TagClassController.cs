using System;
using miniMVC.Models;
using System.Web.Mvc;
using PagedList;
using System.Collections.Generic;

namespace miniMVC.Controllers
{
    public class TagClassController : Controller
    {
        // GET: TagClass
        public ActionResult Index(int id,int page=1)
        {
            TagOperate operate = new TagOperate();
            string name = operate.getIdName(id);
            ViewBag.TagName = name;
            ArticleToTagOperate operate1 = new ArticleToTagOperate();
            var list = operate1.select(1, id);
            ArticleOperate operate2 = new ArticleOperate();
            List<ArticleModel> dataList = new List<ArticleModel>;
            foreach(var a in list)
            {
                ArticleModel thisData = new ArticleModel();
                thisData = operate2.getOneArticle(a.Article_Id);
                dataList.Add(thisData);
            }
            
            var data = dataList.ToPagedList(page, 10);
            return View(data);
        }

        [ChildActionOnly]
        public ActionResult GetTag()
        {
            TagOperate operate = new TagOperate();
            return PartialView("~/Views/_BarPartialPage.cshtml", operate.get());
        }
    }
}