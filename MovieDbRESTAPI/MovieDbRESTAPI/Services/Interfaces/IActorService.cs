using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.ResponseModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Services.Interfaces
{
    public interface IActorService
    {
        IEnumerable<ActorResponse> Get();
        ActorResponse Get(int id);
        IEnumerable<ActorResponse> GetByMovieId(int movieId);
        int Create(ActorRequest actorRequest);
        void Update(int id, ActorRequest actorRequest);
        void Delete(int id);
    }
}
