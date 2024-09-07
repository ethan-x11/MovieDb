using IMDbRESTAPI.CustomExceptions;
using IMDbRESTAPI.Models.RequestModels;
using System.Linq;
using System;
using IMDbRESTAPI.Services.Interfaces;

namespace IMDbRESTAPI.Helper.DataValidators
{
    public class RequestDataValidator
    {
        public static void ValidateMovieRequest(MovieRequest movieRequest, IActorService actorService, IProducerService producerService, IGenreService genreService)
        {
            if (string.IsNullOrWhiteSpace(movieRequest.Title))
                throw new EmptyDataException("Movie Title");

            if (movieRequest.YearOfRelease < 1800 || movieRequest.YearOfRelease > DateTime.Now.Year + 10)
                throw new InvalidDataException("Year");

            try
            {
                producerService.Get(movieRequest.ProducerId);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Producer Id", ex);
            }

            if (string.IsNullOrWhiteSpace(movieRequest.Language))
                throw new EmptyDataException("Language");

            try
            {
                var actors = actorService.Get().ToList();
                movieRequest.ActorIds.ToList().ForEach(actorId =>
                {
                    if (!actors.Any(a => a.Id == actorId))
                        throw new DataNotFoundException($"Actor with id {actorId}");
                });
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Actor Id", ex);
            }

            try
            {
                var genres = genreService.Get().ToList();
                movieRequest.GenreIds.ToList().ForEach(genreId =>
                {
                    if (!genres.Any(g => g.Id == genreId))
                        throw new DataNotFoundException($"Genre with id {genreId}");
                });
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Genre Id", ex);
            }
        }

        public static void ValidateActorRequest(ActorRequest actorRequest)
        {
            if (string.IsNullOrWhiteSpace(actorRequest.Name))
                throw new EmptyDataException("Actor Name");

            if (string.IsNullOrWhiteSpace(actorRequest.Gender))
                throw new EmptyDataException("Gender");

            if (!Enum.IsDefined(typeof(Genders), actorRequest.Gender.ToString().ToUpper()))
                throw new InvalidDataException("Gender");

            if (string.IsNullOrWhiteSpace(actorRequest.DOB.ToString()))
                throw new EmptyDataException("DOB");

            if (!DateTime.TryParse(actorRequest.DOB.ToString(), out _))
                throw new InvalidDataException("DOB");
        }

        public static void ValidateProducerRequest(ProducerRequest producerRequest)
        {
            if (string.IsNullOrWhiteSpace(producerRequest.Name))
                throw new EmptyDataException("Producer Name");

            if (string.IsNullOrWhiteSpace(producerRequest.Gender))
                throw new EmptyDataException("Gender");

            if (!Enum.IsDefined(typeof(Genders), producerRequest.Gender.ToString().ToUpper()))
                throw new InvalidDataException("Gender");

            if (string.IsNullOrWhiteSpace(producerRequest.DOB.ToString()))
                throw new EmptyDataException("DOB");

            if (!DateTime.TryParse(producerRequest.DOB.ToString(), out _))
                throw new InvalidDataException("DOB");
        }
    }
}
