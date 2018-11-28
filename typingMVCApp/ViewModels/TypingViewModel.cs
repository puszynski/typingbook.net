using System.Collections.Generic;
using TypingMVCApp.Helper;

namespace TypingMVCApp.ViewModels
{
    public class TypingViewModel
    {
        public int BookID { get; set; }
        public List<string> BookPages { get; set; }
        public string BookTitle { get; set; }
        public int CurrentBookPage { get; set; }
        public List<string> BookAuthors { get; set; }        
    }
}