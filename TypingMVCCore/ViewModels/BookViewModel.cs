using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypingMVCCore.DomainModels;

namespace TypingMVCCore.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }
    }
}
