using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TypingMVCCore.DomainModels
{
    public class Note
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Note Title")]
        public string NoteTitle { get; set; }

        [Required]
        public string NoteContent { get; set; }


        // ToDo - relacja one to one
        //public virtual User User { get; set; }

        //vs.

        //public int UserID { get; set; }
        //public User User { get; set; }
    }
}
