using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.ResponseModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Services.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<ReviewResponse> Get(int movieId);
        ReviewResponse Get(int movieId, int id);
        int Create(int movieId, ReviewRequest reviewRequest);
        void Update(int movieId, int id, ReviewRequest reviewRequest);
        void Delete(int movieId, int id);
    }
}
