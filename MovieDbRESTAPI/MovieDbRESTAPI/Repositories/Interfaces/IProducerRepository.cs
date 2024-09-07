using IMDbRESTAPI.Models.DbModels;
using System.Collections.Generic;

namespace IMDbRESTAPI.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        IEnumerable<Producer> Get();
        Producer Get(int id);
        int Create(Producer producer);
        bool Update(Producer producer);
        bool Delete(int id);
    }
}
