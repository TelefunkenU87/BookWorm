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

        public BooksDTO AddBook(BooksDTO addBook)
        {
            var procedure = "spAddBook";
            var parameters = new
            {
                @AuthorId = addBook.AuthorId,
                @SeriesId = addBook.SeriesId,
                @Title = addBook.Title,
                @Description = addBook.Description,
                @Rating = addBook.Rating,
                @CoverArt = addBook.CoverArt
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addBook;
        }

        public void DeleteBook(int bookId)
        {
            var procedure = "spDeleteBook";
            var parameters = new { @Id = bookId };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }

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

        public List<BooksDTO> GetBookByAuthor(int authorId)
        {
            var procedure = "spGetBooksByAuthor";
            var parameters = new { @AuthorId = authorId };
            var books = new List<BooksDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                books = conn.Query<BooksDTO>(procedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return books;
        }

        public List<BooksDTO> GetBooksByRating(int rating)
        {
            throw new NotImplementedException();
        }

        public List<BooksDTO> GetBooksBySeries(int seriesId)
        {
            var procedure = "spGetBooksBySeries";
            var parameters = new { @SeriesId = seriesId };
            var series = new List<BooksDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                series = conn.Query<BooksDTO>(procedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return series;
        }

        public BooksDTO GetLatestBook()
        {
            var procedure = "spGetLatestBook";
            var book = new BooksDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                book = conn.QueryFirstOrDefault<BooksDTO>(procedure, commandType: CommandType.StoredProcedure);
            }
            return book;
        }

        public BooksDTO UpdateBook(BooksDTO updateBook)
        {
            var procedure = "spUpdateBook";
            var parameters = new {
                @Id = updateBook.Id,
                @AuthorId = updateBook.AuthorId,
                @SeriesId = updateBook.SeriesId,
                @Title = updateBook.Title,
                @Description = updateBook.Description,
                @Rating = updateBook.Rating,
                @CoverArt = updateBook.CoverArt
            };

            using(IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updateBook;
        }
    }
}
