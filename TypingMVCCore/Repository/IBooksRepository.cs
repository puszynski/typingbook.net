using System.Linq;
using TypingMVCCore.DomainModels;

namespace TypingMVCCore.Repository
{
    public interface IBooksRepository
    {
        IQueryable<Book> GetAllBooks();
        Book GetBookByID(int bookID);

        IQueryable<Author> GetAllAuthors();
        IQueryable<Author> GetAuthorsByBookID(int bookID);
    }
}
