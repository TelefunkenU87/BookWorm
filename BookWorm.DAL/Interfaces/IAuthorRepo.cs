using System;
using System.Collections.Generic;
using System.Text;
using BookWorm.DTO;

namespace BookWorm.DAL.Interfaces
{
    public interface IAuthorRepo
    {
        AuthorsDTO AddAuthor(AuthorsDTO addAuthor);
        int DeleteAuthor(int authorId);
        List<AuthorsDTO> GetAllAuthors();
        AuthorsDTO GetAuthorById(int authorId);
        AuthorsDTO GetAuthorByName(string authorName);
        AuthorsDTO GetLatestAuthor();
        AuthorsDTO UpdateAuthor(AuthorsDTO updateAuthor);
    }
}
