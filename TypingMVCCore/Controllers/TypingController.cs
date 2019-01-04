using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TypingMVCCore.Data;
using TypingMVCCore.Helpers;
using TypingMVCCore.ViewModels;

namespace TypingMVCCore.Controllers
{
    public class TypingController : Controller
    {
        private const int _defaultBook = 3; 
        private readonly ApplicationDbContext _context;
        
        public TypingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Typing/Index?bookid=3&bookPage=2 
        // Typing?bookid=3&bookPage=2
        public IActionResult Index(int bookID = _defaultBook, int bookPage = 0)
        {
            var book = _context.Book.Find(bookID);
            
            if (bookID == 1)
                ViewBag.IsIntroduction = true;

            var typingHelper = new TypingHelper();
            var bookPages = typingHelper.DivideBook(book.BookContent);

            var authorNamesHelper = new GetAuthorsFullNameListHelper(_context);
            var bookAuthors = authorNamesHelper.GetNames();

            var model = new TypingViewModel()
            {
                BookAuthors = bookAuthors,
                CurrentBookPage = bookPage,
                BookPages = bookPages,
                BookTitle = book.BookTitle,
                BookID = bookID
            };
            return View(model);
        }
    }
}