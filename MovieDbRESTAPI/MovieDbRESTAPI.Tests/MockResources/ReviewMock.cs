using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IMDbRESTAPI.Tests.MockResources
{
    public class ReviewMock
    {
        public static readonly Mock<IReviewRepository> ReviewRepoMock = new Mock<IReviewRepository>();

        private static readonly IEnumerable<Review> ListOfReviews = new List<Review>
        {
            new Review
            {
                Id = 1,
                Message = "Review 1 Movie 1",
                MovieId = 1
            },
            new Review
            {
                Id = 2,
                Message = "Review 2 Movie 1",
                MovieId = 1
            },
            new Review
            {
                Id = 1,
                Message = "Review 1 Movie 2",
                MovieId = 2
            },
            new Review
            {
                Id = 2,
                Message = "Review 2 Movie 2",
                MovieId = 2
            }
        };

        public static void MockGetAll()
        {
            ReviewRepoMock.Setup(reviews => reviews.Get(It.IsAny<int>()))
                .Returns((int movieId) =>
                        ListOfReviews.ToList()
                                     .FindAll(review => review.MovieId == movieId)
                );
        }

        public static void MockGetById()
        {
            ReviewRepoMock.Setup(reviews => reviews.Get(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int movieId, int id) =>
                        ListOfReviews.ToList()
                                     .FirstOrDefault(review => review.MovieId == movieId && review.Id == id)
            );
        }

        public static void MockCreate()
        {
            ReviewRepoMock.Setup(reviews => reviews.Create(It.IsAny<Review>()))
                .Returns((Review review) =>
                        ListOfReviews.ToList().Last(r => r.MovieId == review.MovieId).Id + 1
                );
        }

        public static void MockUpdate()
        {
            ReviewRepoMock.Setup(reviews => reviews.Update(It.IsAny<Review>()))
                .Returns(true);
        }

        public static void MockDelete()
        {
            ReviewRepoMock.Setup(reviews => reviews.Delete(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);
        }
    }
}
