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
            TagOperate tag_operate = new TagOperate();
            string name = tag_operate.getIdName(id);
            ViewBag.TagName = name;
            ArticleToTagOperate a_t_operate = new ArticleToTagOperate();
            var list = a_t_operate.select(1, id);
            ArticleOperate article_operate = new ArticleOperate();
            List<ArticleModel> dataList = new List<ArticleModel>();
            foreach(var a in list)
            {
                ArticleModel thisData = new ArticleModel();
                thisData = article_operate.getOneArticle(a.Article_Id);
                dataList.Add(thisData);
            }
            ViewBag.dataList = dataList;
            var data = dataList.ToPagedList(pageNumber:page, pageSize:10);
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