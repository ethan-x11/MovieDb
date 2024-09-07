using Dapper;
using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Models.RequestModels.FilterRequests;
using IMDbRESTAPI.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IMDbRESTAPI.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDbDb) { }

        public IEnumerable<Movie> Get(MovieFilterRequest movieFilterRequest)
        {
            var joins = string.Empty;
            var filters = @" Where 1=1";
            var order = @" ORDER BY M.[Id]";

            var queryParameters = new DynamicParameters();

            const string query = @"
                                SELECT M.[Id], 
                                [Title],
                                [YearOfRelease],    
                                [Plot],
                                [ProducerId],
                                [Poster],
                                [Language],
                                [Profit]
                                FROM [Foundation].[Movies] M
                                (NOLOCK)
                                ";

            if (movieFilterRequest.Year.HasValue)
            {
                filters += @" AND M.[YearOfRelease] = @Year";

                queryParameters.Add("Year", movieFilterRequest.Year);
            }

            if (!string.IsNullOrWhiteSpace(movieFilterRequest.Language))
            {
                filters += @" AND M.[Language] = @Language";

                queryParameters.Add("Language", movieFilterRequest.Language);
            }

            if (!string.IsNullOrWhiteSpace(movieFilterRequest.Genre))
            {
                joins += @" JOIN [Foundation].[GenresMovies] GM
                                ON M.Id = GM.MovieId
                                JOIN [Foundation].[Genres] G
                                ON GM.GenreId = G.Id";

                filters += @" AND G.Name = @Genre";

                queryParameters.Add("Genre", movieFilterRequest.Genre);
            }

            if (!string.IsNullOrWhiteSpace(movieFilterRequest.SortBy) && new string[] { "title", "yearofrelease", "language", "profit" }.Contains(movieFilterRequest.SortBy.ToLower()))
                order = $" ORDER BY M.{movieFilterRequest.SortBy}";


            if (!string.IsNullOrWhiteSpace(movieFilterRequest.Order) && movieFilterRequest.Order == "desc")
                order += @" DESC";

            return GetByCondition(query + joins + filters + order, queryParameters);
        }

        public Movie Get(int id)
        {
            const string query = @"
                                SELECT [Id], 
                                [Title],
                                [YearOfRelease],    
                                [Plot],
                                [ProducerId],
                                [Poster],
                                [Language],
                                [Profit]
                                FROM [Foundation].[Movies] M
                                (NOLOCK)
                                WHERE [Id] = @id    
                                ";

            return Get(query, new { id });
        }

        public int Create(Movie movie, IEnumerable<int> actorIds, IEnumerable<int> genreIds)
        {
            const string query = @"usp_AddMovieDetails";

            return Create(query,
                new
                {
                    title = movie.Title,
                    yearOfRelease = movie.YearOfRelease,
                    plot = movie.Plot,
                    producerId = movie.ProducerId,
                    poster = movie.Poster,
                    language = movie.Language,
                    profit = movie.Profit,
                    actorIds = string.Join(',', actorIds),
                    genreIds = string.Join(',', genreIds)
                },
                CommandType.StoredProcedure
                );
        }

        public bool Update(Movie movie, IEnumerable<int> actorIds, IEnumerable<int> genreIds)
        {
            const string query = @"usp_UpdateMovieDetails";

            return Update(query,
                new
                {
                    id = movie.Id,
                    title = movie.Title,
                    yearOfRelease = movie.YearOfRelease,
                    plot = movie.Plot,
                    producerId = movie.ProducerId,
                    poster = movie.Poster,
                    language = movie.Language,
                    profit = movie.Profit,
                    actorIds = string.Join(',', actorIds),
                    genreIds = string.Join(',', genreIds)
                },
                CommandType.StoredProcedure
                );
        }

        public bool Delete(int id)
        {
            const string query = @"usp_DeleteMovieDetails";

            return Delete(query, new { id }, CommandType.StoredProcedure);
        }
    }
}
