using IMDbRESTAPI.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDbRESTAPI.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Actor Resource")]

    public class ActorSteps : BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario("@GetAllActors")]
        public static void GetAllActors()
        {
            ActorMock.MockGetAll();
        }

        [BeforeScenario("@GetActorById")]
        public static void GetActorById()
        {
            ActorMock.MockGetById();
        }

        [BeforeScenario("@CreateActor")]
        public static void CreateActor()
        {
            ActorMock.MockCreate();
        }

        [BeforeScenario("@UpdateActor")]
        public static void UpdateActor()
        {
            ActorMock.MockUpdate();
        }

        [BeforeScenario("@DeleteActor")]
        public static void DeleteActor()
        {
            ActorMock.MockDelete();
        }
    }
}
