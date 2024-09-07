using IMDbRESTAPI.Models.DbModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Repositories.Interfaces
{
    public interface IActorRepository
    {
        IEnumerable<Actor> Get();
        Actor Get(int id);
        IEnumerable<Actor> GetByMovieId(int movieId);
        int Create(Actor actor);
        bool Update(Actor actor);
        bool Delete(int id);
    }
}
