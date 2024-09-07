using IMDbRESTAPI.Models.DbModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> Get(int movieId);
        Review Get(int movieId, int id);
        int Create(Review review);
        bool Update(Review review);
        bool Delete(int movieId, int id);
    }
}
