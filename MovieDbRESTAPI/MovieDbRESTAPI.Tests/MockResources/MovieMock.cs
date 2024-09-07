using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;
using IMDbRESTAPI.Models.RequestModels.FilterRequests;

namespace IMDbRESTAPI.Tests.MockResources
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> MovieRepoMock = new Mock<IMovieRepository>();

        private static readonly IEnumerable<Movie> ListOfMovies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Test Movie 1",
                YearOfRelease = 2000,
                Plot = "Test Plot 1",
                ProducerId = 1,
                Poster = "Test Poster 1",
                Language = "English",
                Profit = 1000,
            },
            new Movie
            {
                Id = 2,
                Title = "Test Movie 2",
                YearOfRelease = 2000,
                Plot = "Test Plot 2",
                ProducerId = 1,
                Poster = "Test Poster 2",
                Language = "English",
                Profit = 1000,
            }
        };

        public static void MockGetAll()
        {
            MovieRepoMock.Setup(movies => movies.Get(It.IsAny<MovieFilterRequest>()))
                .Returns(ListOfMovies.ToList());
        }

        public static void MockGetById()
        {
            MovieRepoMock.Setup(movies => movies.Get(It.IsAny<int>()))
                .Returns((int id) => ListOfMovies.ToList()
                .FirstOrDefault(x => x.Id == id)
            );
        }

        public static void MockCreate()
        {
            MovieRepoMock.Setup(movies => movies.Create(It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .Returns(ListOfMovies.Last().Id+1);
        }

        public static void MockUpdate()
        {
            MovieRepoMock.Setup(movies => movies.Update(It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .Returns(true);
        }

        public static void MockDelete()
        {
            MovieRepoMock.Setup(movies => movies.Delete(It.IsAny<int>()))
                .Returns(true);
        }
    }
}
