using IMDbRESTAPI.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDbRESTAPI.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Movie Resource")]

    public class MovieSteps : BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => MovieMock.MovieRepoMock.Object);
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                    services.AddScoped(_ => ProducerMock.ProducerRepoMock.Object);
                    services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario("@GetAllMovies")]
        public static void GetAllMovies()
        {
            MovieMock.MockGetAll();
            ActorMock.MockGetByMovieId();
            ProducerMock.MockGetById();
            GenreMock.MockGetByMovieId();
        }

        [BeforeScenario("@GetMovieById")]
        public static void GetMovieById()
        {
            MovieMock.MockGetById();
        }

        [BeforeScenario("@CreateMovie")]
        public static void CreateMovie()
        {
            MovieMock.MockCreate();
        }

        [BeforeScenario("@UpdateMovie")]
        public static void UpdateMovie()
        {
            MovieMock.MockUpdate();
        }

        [BeforeScenario("@DeleteMovie")]
        public static void DeleteMovie()
        {
            MovieMock.MockDelete();
        }
    }
}
