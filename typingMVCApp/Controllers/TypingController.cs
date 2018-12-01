using System.Collections.Generic;
using System.Web.Mvc;
using TypingMVCApp.DAL;
using TypingMVCApp.Helper;
using TypingMVCApp.ViewModels;

namespace TypingMVCApp.Controllers
{
    public class TypingController : Controller
    {
        private EntityFrameworkDBContext db = new EntityFrameworkDBContext();

        // GET: Typing
        public ActionResult Index(int bookID = 1, int bookPage = 0)
         {
            var book = db.Books.Find(bookID);
            var authors = "Test Author1" + ", " + "Test Author2";
            var typingHelper = new TypingHelper();

            if (bookID == 1)
                ViewBag.IsIntroduction = true;

            var model = new TypingViewModel()
            {
                BookAuthors = authors,
                CurrentBookPage = bookPage,
                BookPages = typingHelper.DivideBook(book.BookContent),
                BookTitle = book.BookTitle,
                BookID = bookID
            };
            return View(model);
        }
    }
}