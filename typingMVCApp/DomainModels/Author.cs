﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TypingMVCApp.DomainModels
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}