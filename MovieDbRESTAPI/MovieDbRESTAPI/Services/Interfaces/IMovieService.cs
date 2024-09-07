using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.RequestModels.FilterRequests;
using IMDbRESTAPI.Models.ResponseModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieResponse> Get(MovieFilterRequest movieFilterRequest);
        MovieResponse Get(int id);
        int Create(MovieRequest movieRequest);
        void Update(int id, MovieRequest movieRequest);
        void Delete(int id);
    }
}
