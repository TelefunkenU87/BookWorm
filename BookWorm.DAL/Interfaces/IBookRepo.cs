using System;
using System.Collections.Generic;
using System.Text;
using BookWorm.DTO;

namespace BookWorm.DAL.Interfaces
{
    public interface IBookRepo
    {
        BooksDTO AddBook(BooksDTO addBook);
        void DeleteBook(int bookId);
        List<BooksDTO> GetAllBooks();
        BooksDTO GetBookById(int bookId);
        List<BooksDTO> GetBooksByRating(int rating);
        List<BooksDTO> GetBooksBySeries(int seriesId);
        BooksDTO GetBookBytitle(string title);
        BooksDTO GetLatestBook();
        BooksDTO UpdateBook(BooksDTO updateBook);
    }
}
