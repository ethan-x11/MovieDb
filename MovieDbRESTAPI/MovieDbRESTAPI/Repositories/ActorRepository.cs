using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;

namespace IMDbRESTAPI.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDbDb) { }

        public IEnumerable<Actor> Get()
        {
            const string query = @"
                                SELECT [Id], 
                                [Name], 
                                [Sex] AS [Gender], 
                                [DOB], 
                                [Bio] 
                                FROM [Foundation].[Actors]
                                (NOLOCK)
                                ";

            return Get(query);
        }

        public Actor Get(int id)
        {
            const string query = @"
                                SELECT [Id], 
                                [Name], 
                                [Sex] AS [Gender], 
                                [DOB], 
                                [Bio] 
                                FROM [Foundation].[Actors]
                                (NOLOCK)
                                WHERE [Id] = @id    
                                ";

            return Get(query, new { id });
        }

        public IEnumerable<Actor> GetByMovieId(int movieId)
        {
            const string query = @"
                                SELECT A.[Id], 
                                A.[Name], 
                                A.[Sex] AS [Gender], 
                                A.[DOB], 
                                A.[Bio] 
                                FROM [Foundation].[Actors] A 
                                INNER JOIN [Foundation].[ActorsMovies] AM ON A.[Id] = AM.[ActorId]
                                WHERE AM.[MovieId] = @movieId
                                ";

            return GetByMovieId(query, new { movieId });
        }


        public int Create(Actor actor)
        {
            const string query = @"usp_AddActorDetails";

            return Create(query,
                new
                {
                    name = actor.Name,
                    sex = actor.Gender,
                    dob = actor.DOB,
                    bio = actor.Bio
                },
                CommandType.StoredProcedure
                );
        }

        public bool Update(Actor actor)
        {
            const string query = @"usp_UpdateActorDetails";

            return Update(query,
                new
                {
                    id = actor.Id,
                    name = actor.Name,
                    sex = actor.Gender,
                    dob = actor.DOB,
                    bio = actor.Bio
                },
                CommandType.StoredProcedure
                );
        }

        public bool Delete(int id)
        {
            const string query = @"usp_DeleteActorDetails";

            return Delete(query, new { id }, CommandType.StoredProcedure);
        }
    }
}
