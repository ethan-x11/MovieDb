using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IMDbRESTAPI.Tests.MockResources
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();

        private static readonly IEnumerable<Producer> ListOfProducers = new List<Producer>
        {
            new Producer
            {
                Id = 1,
                Name = "Test Producer 1",
                Gender = "M",
                DOB = new DateTime(1965,04,04),
                Bio = "Test Bio 1"
            },
            new Producer
            {
                Id = 2,
                Name = "Test Producer 2",
                Gender = "M",
                DOB = new DateTime(1981,06,13),
                Bio = "Test Bio 2"
            }
        };

        public static void MockGetAll()
        {
            ProducerRepoMock.Setup(producers => producers.Get())
                .Returns(ListOfProducers.ToList());
        }

        public static void MockGetById()
        {
            ProducerRepoMock.Setup(producers => producers.Get(It.IsAny<int>()))
                .Returns((int id) => ListOfProducers.ToList()
                                                 .FirstOrDefault(x => x.Id == id)
            );
        }

        public static void MockCreate()
        {
            ProducerRepoMock.Setup(producers => producers.Create(It.IsAny<Producer>()))
                .Returns(ListOfProducers.Last().Id+1);
        }

        public static void MockUpdate()
        {
            ProducerRepoMock.Setup(producers => producers.Update(It.IsAny<Producer>()))
                .Returns(true);
        }

        public static void MockDelete()
        {
            ProducerRepoMock.Setup(producers => producers.Delete(It.IsAny<int>()))
                .Returns(true);
        }
    }
}
