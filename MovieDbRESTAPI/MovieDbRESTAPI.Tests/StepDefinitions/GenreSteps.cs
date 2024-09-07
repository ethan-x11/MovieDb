using IMDbRESTAPI.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDbRESTAPI.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Genre Resource")]

    public class GenreSteps : BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario("@GetAllGenres")]
        public static void GetAllGenres()
        {
            GenreMock.MockGetAll();
        }

        [BeforeScenario("@GetGenreById")]
        public static void GetGenreById()
        {
            GenreMock.MockGetById();
        }

        [BeforeScenario("@CreateGenre")]
        public static void CreateGenre()
        {
            GenreMock.MockCreate();
        }

        [BeforeScenario("@UpdateGenre")]
        public static void UpdateGenre()
        {
            GenreMock.MockUpdate();
        }

        [BeforeScenario("@DeleteGenre")]
        public static void DeleteGenre()
        {
            GenreMock.MockDelete();
        }
    }
}
