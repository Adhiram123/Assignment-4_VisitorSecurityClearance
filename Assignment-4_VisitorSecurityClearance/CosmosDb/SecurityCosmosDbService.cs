using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Microsoft.Azure.Cosmos;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public class SecurityCosmosDbService :ISecurityCosmosDbService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;
        public SecurityCosmosDbService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndPoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }
       public async Task<SecurityEntity> AddSecurity(SecurityEntity securityEntity)
        {
            var response = await _container.CreateItemAsync(securityEntity);

            return securityEntity;
        }

        public  async Task<List<SecurityEntity>> GetAll()
        {
            var response =  _container.GetItemLinqQueryable<SecurityEntity>(true).Where(q => q.Active == true && q.Archive == false && q.Documentype == "security").ToList();

            return response;
        }

        public async Task<SecurityEntity> GetSecurityByUId(string uid)
        {
            var security =  _container.GetItemLinqQueryable<SecurityEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false && q.Documentype == "security").FirstOrDefault();

            if (security == null)
            {
                return null;
            }
            else
            {
                return security;
            }
        }

        public async Task<SecurityEntity> UpdateSecurity(SecurityDto securityDto)
        {
            var response = _container.GetItemLinqQueryable<SecurityEntity>(true).Where(q => q.UId == securityDto.UId && q.Active == true && q.Archive == false && q.Documentype == "security").FirstOrDefault();
            response.Archive = true;
            response.Active = false;
            await _container.ReplaceItemAsync(response, response.Id);

            return response;
        }

        public async Task<SecurityEntity> Creat(SecurityEntity response)
        {
            response = await _container.CreateItemAsync(response);
            return response;
        }

        public async Task<SecurityEntity> Delete(string uid)
        {
            var response = _container.GetItemLinqQueryable<SecurityEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false && q.Documentype == "security").FirstOrDefault();
            response.Archive = true;
            response.Active = false;

            await _container.ReplaceItemAsync(response, response.Id);
            return response;
        }

        /* public async Task<SecurityEntity> AddSecurity(SecurityEntity securityEntity)
         {
             var response = await _container.CreateItemAsync(securityEntity);
             return securityEntity;
         }*/
    }
}
