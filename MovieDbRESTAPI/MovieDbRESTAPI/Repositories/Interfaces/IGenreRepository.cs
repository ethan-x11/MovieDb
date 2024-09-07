using IMDbRESTAPI.Models.DbModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Get();
        Genre Get(int id);
        IEnumerable<Genre> GetByMovieId(int movieId);
        int Create(Genre genre);
        bool Update(Genre genre);
        bool Delete(int id);
    }
}
