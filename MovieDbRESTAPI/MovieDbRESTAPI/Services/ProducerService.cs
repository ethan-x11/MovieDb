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
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public ProducerService(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProducerResponse> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<ProducerResponse>>(_producerRepository.Get().ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Producer Data!", ex);
            }
        }

        public ProducerResponse Get(int id)
        {
            Producer producer;
            try
            {
                producer = _producerRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Producer Data!", ex);
            }

            if (producer == null)
                throw new DataNotFoundException($"Producer with Id {id}");

            return _mapper.Map<ProducerResponse>(producer);
        }

        public int Create(ProducerRequest producerRequest)
        {
            RequestDataValidator.ValidateProducerRequest(producerRequest);

            try
            {
                return _producerRepository.Create(_mapper.Map<Producer>(producerRequest));
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Create Producer!", ex);
            }
        }

        public void Update(int id, ProducerRequest producerRequest)
        {

            Get(id);

            RequestDataValidator.ValidateProducerRequest(producerRequest);

            var producer = _mapper.Map<Producer>(producerRequest);
            producer.Id = id;

            try
            {
                _producerRepository.Update(producer);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Update Producer!", ex);
            }
        }

        public void Delete(int id)
        {
            Get(id);

            try
            {
                _producerRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Delete Producer!", ex);
            }
        }
    }
}
