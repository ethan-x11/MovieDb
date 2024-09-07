using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace IMDbRESTAPI.Tests.MockResources
{
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();

        private static readonly IEnumerable<Genre> ListOfGenres = new List<Genre>
        {
            new Genre
            {
                Id = 1,
                Name = "Test Genre 1"
            },
            new Genre
            {
                Id = 2,
                Name = "Test Genre 2"
            }
        };

        private static readonly List<Tuple<int, int>> listOfGenresMovies = new List<Tuple<int, int>>
            {
                Tuple.Create(1, 1),
                Tuple.Create(2, 1),
                Tuple.Create(1, 2),
                Tuple.Create(2, 2)
            };
        public static void MockGetAll()
        {
            GenreRepoMock.Setup(genres => genres.Get())
                .Returns(ListOfGenres.ToList());
        }

        public static void MockGetById()
        {
            GenreRepoMock.Setup(genres => genres.Get(It.IsAny<int>()))
                .Returns((int id) => ListOfGenres.ToList()
                .FirstOrDefault(x => x.Id == id)
            );
        }

        public static void MockCreate()
        {
            GenreRepoMock.Setup(genres => genres.Create(It.IsAny<Genre>()))
                .Returns(ListOfGenres.Last().Id+1);
        }

        public static void MockUpdate()
        {
            GenreRepoMock.Setup(genres => genres.Update(It.IsAny<Genre>()))
                .Returns(true);
        }

        public static void MockDelete()
        {
            GenreRepoMock.Setup(genres => genres.Delete(It.IsAny<int>()))
                .Returns(true);
        }

        public static void MockGetByMovieId()
        {
            GenreRepoMock.Setup(genres => genres.GetByMovieId(It.IsAny<int>()))
                .Returns((int movieId) => listOfGenresMovies
                                            .Where(combination => combination.Item2 == movieId)
                                            .Select(combination => combination.Item1)
                                            .Select(genreId => ListOfGenres.ToList().Find(genre => genre.Id == genreId))
                );
        }
    }
}
