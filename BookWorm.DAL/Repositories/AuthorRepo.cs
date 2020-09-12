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
    public class AuthorRepo : IAuthorRepo
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public AuthorRepo(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }
        public AuthorsDTO AddAuthor(AuthorsDTO addAuthor)
        {
            var procedure = "spAddAuthor";
            var parameters = new
            {
                @FirstName = addAuthor.FirstName,
                @LastName = addAuthor.LastName
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addAuthor;
        }

        public int DeleteAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public List<AuthorsDTO> GetAllAuthors()
        {
            var procedure = "spGetAllAuthors";
            var authors = new List<AuthorsDTO>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                authors = conn.Query<AuthorsDTO>(procedure).ToList();
            }
            return authors;
        }

        public AuthorsDTO GetAuthorById(int authorId)
        {
            var procedure = "spGetAuthorById";
            var parameters = new { @AuthorId = authorId };
            var author = new AuthorsDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                author = conn.QueryFirstOrDefault<AuthorsDTO>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return author;
        }

        public AuthorsDTO GetAuthorByName(string authorName)
        {
            throw new NotImplementedException();
        }

        public AuthorsDTO GetLatestAuthor()
        {
            var procedure = "spGetLatestAuthor";
            var author = new AuthorsDTO();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                author = conn.QueryFirstOrDefault<AuthorsDTO>(procedure, commandType: CommandType.StoredProcedure);
            }
            return author;
        }

        public AuthorsDTO UpdateAuthor(AuthorsDTO updateAuthor)
        {
            var procedure = "spUpdateAuthor";
            var parameters = new
            {
                @Id = updateAuthor.Id,
                @FirstName = updateAuthor.FirstName,
                @LastName = updateAuthor.LastName
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updateAuthor;
        }
    }
}
