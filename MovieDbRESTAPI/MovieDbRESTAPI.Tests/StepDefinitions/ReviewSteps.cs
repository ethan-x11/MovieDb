using IMDbRESTAPI.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDbRESTAPI.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Review Resource")]

    public class ReviewSteps : BaseSteps
    {
        public ReviewSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ReviewMock.ReviewRepoMock.Object);
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                    services.AddScoped(_ => ProducerMock.ProducerRepoMock.Object);
                    services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                    services.AddScoped(_ => MovieMock.MovieRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario("@GetAllReviews")]
        public static void GetAllReviews()
        {
            ReviewMock.MockGetAll();
        }

        [BeforeScenario("@GetReviewById")]
        public static void GetReviewById()
        {
            ReviewMock.MockGetById();
        }

        [BeforeScenario("@CreateReview")]
        public static void CreateReview()
        {
            ReviewMock.MockCreate();
        }

        [BeforeScenario("@UpdateReview")]
        public static void UpdateReview()
        {
            ReviewMock.MockUpdate();
        }

        [BeforeScenario("@DeleteReview")]
        public static void DeleteReview()
        {
            ReviewMock.MockDelete();
        }
    }
}
