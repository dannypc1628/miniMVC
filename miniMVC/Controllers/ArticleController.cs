﻿using miniMVC.Models;
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
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ArticleOperate article_operate = new ArticleOperate();
            ArticleModel thisData = new ArticleModel();
            thisData = article_operate.getOneArticle((int)id);
            return View(thisData);
        }
        // GET: Article
        public ActionResult Create()
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
                art.Content = data.Content;
                art.Time = DateTime.Now;

                ArticleOperate artOp = new ArticleOperate();
                int Article_Id = artOp.addArticle(art);

                ArticleToTagModel artTag = new ArticleToTagModel();
                artTag.Article_Id = Article_Id;
                artTag.Tag_Id = data.Tag_Id;

                ArticleToTagOperate artToTag = new ArticleToTagOperate();
                artToTag.insert(artTag);

            }
            return RedirectToAction("Index","TagClass",new { id=data.Tag_Id});
        }
    }
}