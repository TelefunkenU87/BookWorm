using System;
using System.Collections.Generic;
using System.Text;
using BookWorm.DTO;

namespace BookWorm.DAL.Interfaces
{
    public interface IAuthorRepo
    {
        int AddAuthor(AuthorsDTO addAuthor);
        int DeleteAuthor(int authorId);
        List<AuthorsDTO> GetAllAuthors();
        AuthorsDTO GetAuthorById(int authorId);
        AuthorsDTO GetAuthorByName(string authorName);
        int UpdateAuthor(AuthorsDTO updateAuthor);
    }
}
