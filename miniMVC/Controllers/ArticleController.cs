using miniMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miniMVC.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            TagOperate tagO = new TagOperate();
            List<TagModel> tag = tagO.get();
            List<SelectListItem> list_Item = new List<SelectListItem>();
            int count =  tag.Count();
            for(int i =0; i< count; i++)
            {
                list_Item.Add(new SelectListItem { Text = tag[i].Name, Value = Convert.ToString(tag[i].Id) });
            }
            ViewBag.TagList = new SelectList(list_Item, "Value", "Text", "");
            return View();
        }
        
        public class NewArticle
        {
            [Required]
            public string Title { get; set; }
            [Required]
            public string Content { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int Tag_Id { get; set; }
        }

        public ActionResult Add(NewArticle data)
        {
            if (ModelState.IsValid)
            {
                ArticleModel art = new ArticleModel();
                art.Name = data.Name;
                art.Title = data.Title;
                art.Contant = data.Content;
                art.Time = DateTime.Now;

                ArticleOperate artOp = new ArticleOperate();
                artOp.addArticle(art);


            }
            return View();
        }
    }
}