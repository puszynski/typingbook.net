using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TypingMVCApp.DomainModels
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public string BookContent { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<Genre> GenresEnum { get; set; }

        [Range(1,10)]
        public int? Rate { get; set; }
    }


    public enum Genre
    {
        NoGenre = 0,
        SciFi = 1,
        Horror = 2,
        Action = 3,
        Travel = 4
    }
}