using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;

namespace IMDbRESTAPI.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDbDb) { }

        public IEnumerable<Genre> Get()
        {
            const string query = @"
                                SELECT [Id], 
                                [Name]
                                FROM [Foundation].[Genres]
                                (NOLOCK)
                                ";

            return Get(query);
        }

        public Genre Get(int id)
        {
            const string query = @"
                                SELECT [Id], 
                                [Name]
                                FROM [Foundation].[Genres]
                                (NOLOCK)
                                WHERE [Id] = @id    
                                ";

            return Get(query, new { id });
        }

        public IEnumerable<Genre> GetByMovieId(int movieId)
        {
            const string query = @"
                                SELECT G.[Id], 
                                G.[Name]
                                FROM [Foundation].[Genres] G 
                                INNER JOIN [Foundation].[GenresMovies] GM ON G.[Id] = GM.[GenreId]
                                WHERE GM.[MovieId] = @movieId
                                ";

            return GetByMovieId(query, new { movieId });
        }


        public int Create(Genre genre)
        {
            const string query = @"usp_AddGenreDetails";

            return Create(query, new { genre.Name }, CommandType.StoredProcedure);
        }

        public bool Update(Genre genre)
        {
            const string query = @"usp_UpdateGenreDetails";

            return Update(query,
                new
                {
                    id = genre.Id,
                    name = genre.Name
                },
                CommandType.StoredProcedure
                );
        }

        public bool Delete(int id)
        {
            const string query = @"usp_DeleteGenreDetails"
            ;

            return Delete(query, new { id }, CommandType.StoredProcedure);
        }
    }
}
