using System;
using miniMVC.Models;
using System.Web.Mvc;

namespace miniMVC.Controllers
{
    public class TagClassController : Controller
    {
        // GET: TagClass
        public ActionResult Index(int id)
        {

            return View();
        }

        [ChildActionOnly]
        public ActionResult GetTag()
        {
            TagOperate operate = new TagOperate();
            return PartialView("~/Views/_BarPartialPage.cshtml", operate.get());
        }
    }
}