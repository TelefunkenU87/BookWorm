using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BookWorm.DTO;
using BookWorm.DAL.Interfaces;

namespace BookWorm.DAL.Repositories
{
    public class BookRepo : IBookRepo
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public BookRepo(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }

        public int AddBook(BooksDTO addBook)
        {
            throw new NotImplementedException();
        }

        public int DeleteBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public List<BooksDTO> GetAllBooks()
        {
            var procedure = "spGetAllBooks";
            var books = new List<BooksDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                books = conn.Query<BooksDTO>(procedure).ToList();
            }
            return books;
        }

        public BooksDTO GetBookById(int bookId)
        {
            var procedure = "spGetBookById";
            var parameters = new { @BookId = bookId };
            var book = new BooksDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                book = conn.QueryFirstOrDefault<BooksDTO>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return book;
        }

        public BooksDTO GetBookBytitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<BooksDTO> GetBooksByRating(int rating)
        {
            throw new NotImplementedException();
        }

        public List<BooksDTO> GetBooksBySeries(int seriesId)
        {
            throw new NotImplementedException();
        }

        public int UpdateBook(BooksDTO updateBook)
        {
            throw new NotImplementedException();
        }
    }
}
