using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TypingMVCApp.Controllers
{
    public class TypingController : Controller
    {
        // GET: Typing
        public ActionResult Index(int bookID = 1, int bookPage = 1)
        {
            return View();
        }
    }
}