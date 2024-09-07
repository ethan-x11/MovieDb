using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IMDbRESTAPI.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDbDb) { }

        public IEnumerable<Review> Get(int movieId)
        {
            const string query = @"
                                SELECT [Id], 
                                [Message],
                                [MovieId]
                                FROM [Foundation].[Reviews]
                                (NOLOCK)
                                ";

            return Get(query).Where(r => r.MovieId == movieId);
        }

        public Review Get(int movieId, int id)
        {
            const string query = @"
                                SELECT [Id], 
                                [Message],
                                [MovieId]
                                FROM [Foundation].[Reviews]
                                (NOLOCK)
                                WHERE [MovieId] = @movieId AND [Id] = @id
                                ";

            return Get(query, new { movieId = movieId, id = id });
        }

        public int Create(Review review)
        {
            const string query = @"usp_AddReviewDetails";

            return Create(query,
                new
                {
                    message = review.Message,
                    movieId = review.MovieId
                },
                CommandType.StoredProcedure
                );
        }

        public bool Update(Review review)
        {
            const string query = @"usp_UpdateReviewDetails";

            return Update(query,
                new
                {
                    id = review.Id,
                    message = review.Message,
                    movieId = review.MovieId
                },
                CommandType.StoredProcedure
                );
        }

        public bool Delete(int movieId, int id)
        {
            const string query = @"usp_DeleteReviewDetails";

            return Delete(query, new { movieId = movieId, id = id }, CommandType.StoredProcedure);
        }
    }
}
