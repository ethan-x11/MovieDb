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
using IMDbRESTAPI.Helper.DataValidators;

namespace IMDbRESTAPI.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public IEnumerable<ActorResponse> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<ActorResponse>>(_actorRepository.Get().ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Actor Data!", ex);
            }
        }

        public ActorResponse Get(int id)
        {
            Actor actor;
            try
            {
                actor = _actorRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Actor Data!", ex);
            }

            if (actor == null)
                throw new DataNotFoundException($"Actor with Id {id}");

            return _mapper.Map<ActorResponse>(actor);
        }

        public IEnumerable<ActorResponse> GetByMovieId(int movieId)
        {
            try
            {
                return _mapper.Map<IEnumerable<ActorResponse>>(_actorRepository.GetByMovieId(movieId).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Actor Data!", ex);
            }
        }

        public int Create(ActorRequest actorRequest)
        {
            RequestDataValidator.ValidateActorRequest(actorRequest);

            try
            {
                return _actorRepository.Create(_mapper.Map<Actor>(actorRequest));
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Create Actor!", ex);
            }
        }

        public void Update(int id, ActorRequest actorRequest)
        {

            Get(id);

            RequestDataValidator.ValidateActorRequest(actorRequest);

            var actor = _mapper.Map<Actor>(actorRequest);
            actor.Id = id;

            try
            {
                _actorRepository.Update(actor);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Update Actor!", ex);
            }
        }

        public void Delete(int id)
        {
            Get(id);

            try
            {
                _actorRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Delete Actor!", ex);
            }
        }
    }
}
