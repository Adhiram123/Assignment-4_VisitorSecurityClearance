using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Microsoft.Azure.Cosmos;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public class ManagerCosmosDbService : IManagerCosmosDbService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;
        public ManagerCosmosDbService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndPoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }

        public async Task<List<ManagerEntity>> GetAll()
        {
            var response = _container.GetItemLinqQueryable<ManagerEntity>(true).Where(q => q.Active == true && q.Archive == false && q.Documentype == "manager").ToList();

            return response;
        }

        public async Task<ManagerEntity> AddManager(ManagerEntity managerEntity)
        {
            var response = await _container.CreateItemAsync(managerEntity);

            return managerEntity;
        }

        public async Task<ManagerEntity> GetManagerByUId(string uid)
        {
            var security = _container.GetItemLinqQueryable<ManagerEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false && q.Documentype == "manager").FirstOrDefault();

            if (security == null)
            {
                return null;
            }
            else
            {
                return security;
            }
        }

        public async Task<ManagerEntity> UpdateManager(ManagerDto managerDto)
        {
            var response = _container.GetItemLinqQueryable<ManagerEntity>(true).Where(q => q.UId == managerDto.UId && q.Active == true && q.Archive == false && q.Documentype == "manager").FirstOrDefault();
            response.Archive = true;
            response.Active = false;
            await _container.ReplaceItemAsync(response, response.Id);
            return response;
        }

        public async Task<ManagerEntity> Creat(ManagerEntity response)
        {
            response = await _container.CreateItemAsync(response);
            return response;
        }

        public async Task<ManagerEntity> Delete(string uid)
        {
            var response = _container.GetItemLinqQueryable<ManagerEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false && q.Documentype == "manager").FirstOrDefault();
            response.Archive = true;
            response.Active = false;

            await _container.ReplaceItemAsync(response, response.Id);
            return response;
        }
    }
}
