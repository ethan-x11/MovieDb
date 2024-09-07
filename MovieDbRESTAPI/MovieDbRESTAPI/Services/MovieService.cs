using AutoMapper;
using IMDbRESTAPI.CustomExceptions;
using IMDbRESTAPI.Helper.DataValidators;
using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.RequestModels.FilterRequests;
using IMDbRESTAPI.Models.ResponseModels;
using IMDbRESTAPI.Repositories.Interfaces;
using IMDbRESTAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDbRESTAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorService _actorService;
        private readonly IProducerService _producerService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IActorService actorService, IProducerService producerService, IGenreService genreService, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _actorService = actorService;
            _producerService = producerService;
            _genreService = genreService;
            _mapper = mapper;
        }

        public IEnumerable<MovieResponse> Get(MovieFilterRequest movieFilterRequest)
        {
            try
            {
                var movies = _movieRepository.Get(movieFilterRequest).ToList();

                var movieResponses = _mapper.Map<IEnumerable<MovieResponse>>(movies);

                movies.ForEach(movie =>
                {
                    var movieResponse = movieResponses.First(m => m.Id == movie.Id);
                    movieResponse.Producer = _producerService.Get(movie.ProducerId);
                    movieResponse.Actors = _actorService.GetByMovieId(movie.Id).ToList();
                    movieResponse.Genres = _genreService.GetByMovieId(movie.Id).ToList();
                });

                return movieResponses;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Movie Data!", ex);
            }
        }

        public MovieResponse Get(int id)
        {
            var movie = _movieRepository.Get(id) ?? throw new DataNotFoundException($"Movie with Id {id}");

            try
            {
                var movieResponse = _mapper.Map<MovieResponse>(movie);
                movieResponse.Producer = _producerService.Get(movie.ProducerId);
                movieResponse.Actors = _actorService.GetByMovieId(id).ToList();
                movieResponse.Genres = _genreService.GetByMovieId(id).ToList();

                return movieResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Movie Data!", ex);
            }
        }

        public int Create(MovieRequest movieRequest)
        {
            RequestDataValidator.ValidateMovieRequest(movieRequest, _actorService, _producerService, _genreService);

            var movie = _mapper.Map<Movie>(movieRequest);

            try
            {
                return _movieRepository.Create(movie, movieRequest.ActorIds, movieRequest.GenreIds);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Create Movie!", ex);
            }
        }

        public void Update(int id, MovieRequest movieRequest)
        {
            Get(id);

            RequestDataValidator.ValidateMovieRequest(movieRequest, _actorService, _producerService, _genreService);

            var movie = _mapper.Map<Movie>(movieRequest);
            movie.Id = id;

            try
            {
                _movieRepository.Update(movie, movieRequest.ActorIds, movieRequest.GenreIds);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Update Movie!", ex);
            }
        }

        public void Delete(int id)
        {
            Get(id);

            try
            {
                _movieRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Delete Movie!", ex);
            }
        }
    }
}
