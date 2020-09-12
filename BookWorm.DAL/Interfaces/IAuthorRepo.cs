using System.Collections.Generic;
using BookWorm.DTO;

namespace BookWorm.DAL.Interfaces
{
    public interface IAuthorRepo
    {
        AuthorsDTO AddAuthor(AuthorsDTO addAuthor);
        List<AuthorsDTO> GetAllAuthors();
        AuthorsDTO GetAuthorById(int authorId);
        AuthorsDTO GetLatestAuthor();
        AuthorsDTO UpdateAuthor(AuthorsDTO updateAuthor);
    }
}
