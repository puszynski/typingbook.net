using System.Collections.Generic;

namespace TypingMVCCore.ViewModels
{
    public class TypingViewModel
    {
        public int BookID { get; set; }

        // BookContent devided into list
        public List<string> BookPages { get; set; }

        public string BookTitle { get; set; }
        public int CurrentBookPage { get; set; }
        public string BookAuthors { get; set; }
    }
}
