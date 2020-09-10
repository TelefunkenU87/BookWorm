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
        public int AddAuthor(AuthorsDTO addAuthor)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public AuthorsDTO GetAuthorByName(string authorName)
        {
            throw new NotImplementedException();
        }

        public int UpdateAuthor(AuthorsDTO updateAuthor)
        {
            throw new NotImplementedException();
        }
    }
}
