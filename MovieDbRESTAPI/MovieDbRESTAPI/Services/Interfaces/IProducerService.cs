using IMDbRESTAPI.Models.RequestModels;
using IMDbRESTAPI.Models.ResponseModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Services.Interfaces
{
    public interface IProducerService
    {
        IEnumerable<ProducerResponse> Get();
        ProducerResponse Get(int id);
        int Create(ProducerRequest producerRequest);
        void Update(int id, ProducerRequest producerRequest);
        void Delete(int id);
    }
}
