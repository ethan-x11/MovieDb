using IMDbRESTAPI.Models.DbModels;
using IMDbRESTAPI.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;

namespace IMDbRESTAPI.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDbDb) { }

        public IEnumerable<Producer> Get()
        {
            const string query = @"
                                SELECT [Id], 
                                [Name], 
                                [Sex] AS [Gender], 
                                [DOB], 
                                [Bio] 
                                FROM [Foundation].[Producers]
                                (NOLOCK)
                                ";

            return Get(query);
        }

        public Producer Get(int id)
        {
            const string query = @"
                                SELECT [Id], 
                                [Name], 
                                [Sex] AS [Gender], 
                                [DOB], 
                                [Bio] 
                                FROM [Foundation].[Producers]
                                (NOLOCK)
                                WHERE [Id] = @id    
                                ";

            return Get(query, new { id });
        }

        public int Create(Producer producer)
        {
            const string query = @"usp_AddProducerDetails";

            return Create(query,
                new
                {
                    name = producer.Name,
                    sex = producer.Gender,
                    dob = producer.DOB,
                    bio = producer.Bio
                },
                CommandType.StoredProcedure
                );
        }

        public bool Update(Producer producer)
        {
            const string query = @"usp_UpdateProducerDetails";

            return Update(query,
                new
                {
                    id = producer.Id,
                    name = producer.Name,
                    sex = producer.Gender,
                    dob = producer.DOB,
                    bio = producer.Bio
                },
                CommandType.StoredProcedure
                );
        }

        public bool Delete(int id)
        {
            const string query = @"usp_DeleteProducerDetails";

            return Delete(query, new { id },CommandType.StoredProcedure);
        }
    }
}
