using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IMDbRESTAPI.Tests.MockResources
{
    public class ActorMock
    {
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();

        private static readonly IEnumerable<Actor> ListOfActors = new List<Actor>
        {
            new Actor
            {
                Id = 1,
                Name = "Test Actor 1",
                Gender = "M",
                DOB = new DateTime(1965,04,04),
                Bio = "Test Bio 1"
            },
            new Actor
            {
                Id = 2,
                Name = "Test Actor 2",
                Gender = "M",
                DOB = new DateTime(1981,06,13),
                Bio = "Test Bio 2"
            }
        };

        private static readonly List<Tuple<int, int>> listOfActorsMovies = new List<Tuple<int, int>>
            {
                Tuple.Create(1, 1),
                Tuple.Create(2, 1),
                Tuple.Create(1, 2),
                Tuple.Create(2, 2)
            };

        public static void MockGetAll()
        {
            ActorRepoMock.Setup(actors => actors.Get())
                .Returns(ListOfActors.ToList());
        }

        public static void MockGetById()
        {
            ActorRepoMock.Setup(actors => actors.Get(It.IsAny<int>()))
                .Returns((int id) => ListOfActors.ToList()
                .FirstOrDefault(x => x.Id == id)
            );
        }

        public static void MockCreate()
        {
            ActorRepoMock.Setup(actors => actors.Create(It.IsAny<Actor>()))
                .Returns(ListOfActors.Last().Id+1);
        }

        public static void MockUpdate()
        {
            ActorRepoMock.Setup(actors => actors.Update(It.IsAny<Actor>()))
                .Returns(true);
        }

        public static void MockDelete()
        {
            ActorRepoMock.Setup(actors => actors.Delete(It.IsAny<int>()))
                .Returns(true);
        }

        public static void MockGetByMovieId()
        {
            ActorRepoMock.Setup(actors => actors.GetByMovieId(It.IsAny<int>()))
                .Returns((int movieId) => listOfActorsMovies
                                            .Where(combination => combination.Item2 == movieId)
                                            .Select(combination => combination.Item1)
                                            .Select(actorId => ListOfActors.ToList().Find(actor => actor.Id == actorId))
                );
        }
    }
}
