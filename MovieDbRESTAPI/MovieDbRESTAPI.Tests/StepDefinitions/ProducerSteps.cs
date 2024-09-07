using IMDbRESTAPI.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDbRESTAPI.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Producer Resource")]

    public class ProducerSteps : BaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ProducerMock.ProducerRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario("@GetAllProducers")]
        public static void GetAllProducers()
        {
            ProducerMock.MockGetAll();
        }

        [BeforeScenario("@GetProducerById")]
        public static void GetProducerById()
        {
            ProducerMock.MockGetById();
        }

        [BeforeScenario("@CreateProducer")]
        public static void CreateProducer()
        {
            ProducerMock.MockCreate();
        }

        [BeforeScenario("@UpdateProducer")]
        public static void UpdateProducer()
        {
            ProducerMock.MockUpdate();
        }

        [BeforeScenario("@DeleteProducer")]
        public static void DeleteProducer()
        {
            ProducerMock.MockDelete();
        }
    }
}
