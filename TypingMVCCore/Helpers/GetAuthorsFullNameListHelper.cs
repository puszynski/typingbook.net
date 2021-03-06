﻿using System.Linq;
using TypingMVCCore.Data;

namespace TypingMVCCore.Helpers
{
    public class GetAuthorsFullNameListHelper
    {
        private readonly ApplicationDbContext _context;

        public GetAuthorsFullNameListHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Get(int bookID)
        {
            var result = "";

            var authorsList = _context.Book.Where(x => x.ID == bookID)
                .SelectMany(x => x.BookAuthors)
                .Select(x => x.Author)
                .ToList();
            
            if (authorsList != null)
            {
                foreach (var item in authorsList)
                {
                    if (authorsList.IndexOf(item) == authorsList.Count - 1) 
                        result += item.FirstName + " " + item.LastName; // the last item
                    else
                        result += item.FirstName + " " + item.LastName + ", ";
                }
            }
            return result;
        }
    }
}
