using System.Collections.Generic;
using BookWorm.DTO;

namespace BookWorm.DAL.Interfaces
{
    public interface IBookRepo
    {
        BooksDTO AddBook(BooksDTO addBook);
        void DeleteBook(int bookId);
        List<BooksDTO> GetAllBooks();
        BooksDTO GetBookById(int bookId);
        List<BooksDTO> GetBooksBySeries(int seriesId);
        List<BooksDTO> GetBookByAuthor(int authorId);
        BooksDTO GetLatestBook();
        BooksDTO UpdateBook(BooksDTO updateBook);
    }
}
