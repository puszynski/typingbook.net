using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column(TypeName = "nvarchar(24)")] // konwertuje typ danych
        public BookGenre BookGenre { get; set; }

        public virtual List<BookAuthor> BookAuthors { get; set; }
    }
    
    
    public enum BookGenre
    {
        NoGenre = 0,
        SciFi = 1,
        Horror = 2,
        Action = 3,
        Travel = 4,
        History = 5,
        Biography = 6,
        Drama = 7,
        Documentary = 8,
        Comedy = 9,
        War = 10,

    }
}
