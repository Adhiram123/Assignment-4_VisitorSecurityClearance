using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Microsoft.Azure.Cosmos;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public class OfficeCosmosDbService :IOfficeCosmosDbService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;
        public OfficeCosmosDbService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndPoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }

        public async Task<List<OfficeEntity>> GetAll()
        {
            var response = _container.GetItemLinqQueryable<OfficeEntity>(true).Where(q => q.Active == true && q.Archive == false && q.Documentype == "office").ToList();

            return response;
        }

        public async Task<OfficeEntity> AddOfficer(OfficeEntity officeEntity)
        {
            var response = await _container.CreateItemAsync(officeEntity);

            return officeEntity;
        }

        public async Task<OfficeEntity> GetOfficerByUId(string uid)
        {
            var security = _container.GetItemLinqQueryable<OfficeEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false && q.Documentype == "office").FirstOrDefault();

            if (security == null)
            {
                return null;
            }
            else
            {
                return security;
            }
        }

        public async Task<OfficeEntity> UpdateOffice(OfficeDto officeDto)
        {
            var response = _container.GetItemLinqQueryable<OfficeEntity>(true).Where(q => q.UId == officeDto.UId && q.Active == true && q.Archive == false && q.Documentype == "office").FirstOrDefault();
            response.Archive = true;
            response.Active = false;
            await _container.ReplaceItemAsync(response, response.Id);

            return response;
        }

        public async Task<OfficeEntity> Creat(OfficeEntity response)
        {
            response = await _container.CreateItemAsync(response);
            return response;
        }

        public async Task<OfficeEntity> Delete(string uid)
        {
            var response = _container.GetItemLinqQueryable<OfficeEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false && q.Documentype == "office").FirstOrDefault();
            response.Archive = true;
            response.Active = false;

            await _container.ReplaceItemAsync(response, response.Id);
            return response;
        }
    }
}
