using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Models.RequestModels.FilterRequests;
using System.Collections.Generic;

namespace IMDbRESTAPI.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get(MovieFilterRequest movieFilterRequest);
        Movie Get(int id);
        int Create(Movie movie, IEnumerable<int> actorIds, IEnumerable<int> genreIds);
        bool Update(Movie movie, IEnumerable<int> actorIds, IEnumerable<int> genreIds);
        bool Delete(int id);
    }
}
