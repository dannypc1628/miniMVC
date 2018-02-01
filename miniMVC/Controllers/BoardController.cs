using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miniMVC.Models;

namespace miniMVC.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Index()
        {
            BoardOperate bo = new BoardOperate();
            return View(bo.getData());
        }

        public ActionResult add([Bind (Exclude ="time")] BoardModel data)
        {
            if (ModelState.IsValid)
            {
                BoardOperate bo = new BoardOperate();
                data.time = DateTime.Now;
                bo.addData(data);
            }

                return RedirectToAction("Index");
        }
    }
}