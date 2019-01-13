using System.Linq;
using TypingMVCCore.Data;
using TypingMVCCore.DomainModels;

namespace TypingMVCCore.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAllBooks()
        {
            return _context.Book.Select(x => x);
        }

        public Book GetBookByID(int bookID)
        {
            return _context.Book.Find(bookID);
        }

        // TODO async repo method
        //public async Task<T> GetAsyncBookByID(int bookID, bool IsAsync = false)
        //{
        //    return await _context.Book.FirstOrDefaultAsync(x => x.bookID).Set<T>().ToListAsync(); ;
        //}

        public IQueryable<Author> GetAllAuthors()
        {
            return _context.Author.Select(x => x);
        }

        public IQueryable<Author> GetAuthorsByBookID(int bookID)
        {
            return _context.Book.Where(x => x.ID == bookID)
                .SelectMany(x => x.BookAuthors)
                .Select(x => x.Author);
        }
    }
}
