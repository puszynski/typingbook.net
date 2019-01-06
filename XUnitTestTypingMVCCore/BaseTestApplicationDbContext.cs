using Microsoft.EntityFrameworkCore;
using System;
using TypingMVCCore.Data;
using TypingMVCCore.DomainModels;

// use EF in memory to make xUnit Tests: https://www.youtube.com/watch?v=ddrR440JtiA
// Can be used only with no-releation DB
namespace XUnitTestTypingMVCCore
{
    public class BaseTestApplicationDbContext
    {
        protected ApplicationDbContext _context;

        // ctor in xUnit runs before each tests
        public BaseTestApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             // .UseInMemoryDatabase(databaseName: "ApplicationDb") // MS recomends to use new db name for each test, so we will use guid
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();

            var authors = new[]
            {
                new Author { ID = 1, FirstName = "Bob", LastName = "Code"},
                new Author { ID = 2, FirstName = "John", LastName = "Travolta"},
            };

            var books = new[]
            {
                new Book { ID = 1, BookTitle = "Test title", BookContent = "Test content is here" },
                new Book { ID = 2, BookTitle = "Test title 2", BookContent = "Test content is here 2" }
            };

            _context.Book.AddRange(books);
            _context.Author.AddRange(authors);
            _context.SaveChanges();
        }

        // runs after each method
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose(); 
        }
    }
}
