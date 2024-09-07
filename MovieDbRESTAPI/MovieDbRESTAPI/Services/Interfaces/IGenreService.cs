using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.ResponseModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Services.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<GenreResponse> Get();
        GenreResponse Get(int id);
        IEnumerable<GenreResponse> GetByMovieId(int movieId);
        int Create(GenreRequest genreRequest);
        void Update(int id, GenreRequest genreRequest);
        void Delete(int id);
    }
}
