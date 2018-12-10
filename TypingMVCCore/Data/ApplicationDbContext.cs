using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TypingMVCCore.DomainModels;

namespace TypingMVCCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // mapping two one-to-many into Book-Author many-to-many relation
            modelBuilder.Entity<BookAuthor>().HasKey(t => new { t.BookID, t.AuthorID });
            modelBuilder.Entity<BookAuthor>().HasOne(pt => pt.Book).WithMany(p => p.BookAuthors).HasForeignKey(pt => pt.BookID);
            modelBuilder.Entity<BookAuthor>().HasOne(pt => pt.Author).WithMany(t => t.BookAuthors).HasForeignKey(pt => pt.AuthorID);

            // convert enum into string
            modelBuilder.Entity<Book>().Property(e => e.BookGenre).HasConversion<string>();
        }
    }
}
