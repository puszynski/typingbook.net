using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TypingMVCApp.DomainModels;

namespace TypingMVCApp.DAL
{
    public class EntityFrameworkDBContext : DbContext
    {
        public EntityFrameworkDBContext() : base("EntityFrameworkDBContext")
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}