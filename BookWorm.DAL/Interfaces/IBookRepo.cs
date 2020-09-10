using System;
using System.Collections.Generic;
using System.Text;
using BookWorm.DTO;

namespace BookWorm.DAL.Interfaces
{
    public interface IBookRepo
    {
        int AddBook(BooksDTO addBook);
        int DeleteBook(int bookId);
        List<BooksDTO> GetAllBooks();
        BooksDTO GetBookById(int bookId);
        List<BooksDTO> GetBooksByRating(int rating);
        List<BooksDTO> GetBooksBySeries(int seriesId);
        BooksDTO GetBookBytitle(string title);
        int UpdateBook(BooksDTO updateBook);
    }
}
