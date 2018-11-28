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
        public ActionResult Index(int bookID = 1, int bookPage = 1)
        {
            var book = db.Books.Find(bookID);
            //var authors = db.Authors.Find(); ??
            var typingHelper = new TypingHelper();

            var result = new TypingViewModel()
            {
                BookAuthors = new List<string> { "ToDO1", "ToDO2" },
                CurrentBookPage = bookPage,
                BookPages = typingHelper.DivideBook(book.BookContent),
                BookTitle = book.BookTitle,
                BookID = bookID
            };

            return View(result);
        }
    }
}