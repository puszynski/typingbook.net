﻿using System;
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
        private readonly ApplicationDbContext _context;

        public TypingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int bookID = 1, int bookPage = 0)
        {
            var book = _context.Book.Find(bookID);

            var authorsList = _context.Book.Where(x => x.ID == 1)
                .SelectMany(x => x.BookAuthors)
                .Select(x => x.Author)
                .ToList();

            var authors = "";
            if (authorsList != null)            
            {
                foreach (var item in authorsList)
                {
                    authors = item.FirstName + " " + item.LastName + ", ";
                }
            }
              

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