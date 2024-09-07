using AutoMapper;
using IMDbRESTAPI.CustomExceptions;
using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.ResponseModels;
using IMDbRESTAPI.Repositories.Interfaces;
using IMDbRESTAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDbRESTAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public IEnumerable<GenreResponse> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<GenreResponse>>(_genreRepository.Get().ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Genre Data!", ex);
            }
        }

        public GenreResponse Get(int id)
        {
            Genre genre;
            try
            {
                genre = _genreRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Genre Data!", ex);
            }

            if (genre == null)
                throw new DataNotFoundException($"Genre with Id {id}");

            return _mapper.Map<GenreResponse>(genre);
        }
        public IEnumerable<GenreResponse> GetByMovieId(int movieId)
        {
            try
            {
                return _mapper.Map<IEnumerable<GenreResponse>>(_genreRepository.GetByMovieId(movieId).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Genre Data!", ex);
            }
        }

        public int Create(GenreRequest genreRequest)
        {
            if (string.IsNullOrWhiteSpace(genreRequest.Name))
                throw new EmptyDataException("Genre Name");

            if (Get().ToList().Any(g => g.Name == genreRequest.Name))
                throw new DuplicateDataException("Genre");

            try
            {
                return _genreRepository.Create(_mapper.Map<Genre>(genreRequest));
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Create Genre!", ex);
            }
        }

        public void Update(int id, GenreRequest genreRequest)
        {
            Get(id);

            if (string.IsNullOrWhiteSpace(genreRequest.Name))
                throw new EmptyDataException("Genre Name");

            var genre = _mapper.Map<Genre>(genreRequest);
            genre.Id = id;

            try
            {
                _genreRepository.Update(genre);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Update Genre!", ex);
            }
        }

        public void Delete(int id)
        {
            Get(id);

            try
            {
                _genreRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Delete Genre!", ex);
            }
        }
    }
}
