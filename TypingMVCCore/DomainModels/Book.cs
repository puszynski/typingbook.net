using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TypingMVCCore.DomainModels
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }

        [Required]
        public string BookContent { get; set; }

        [Range(1, 10)]
        public int? Rate { get; set; }
        
        public virtual List<BookAuthor> BookAuthors { get; set; }
        //public ICollection<BookGenre> BookGenre { get; set; }
    }
    
    
    public enum BookGenre
    {
        NoGenre = 0,
        SciFi = 1,
        Horror = 2,
        Action = 3,
        Travel = 4
    }
}
