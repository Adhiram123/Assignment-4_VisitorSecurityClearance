using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public class CosmosDbService : ICosmosDbService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;
        public CosmosDbService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndPoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }
        public async Task<VisitorEntity> AddVisitor(VisitorEntity visitorEntity)
        {
            var response = await _container.CreateItemAsync(visitorEntity);
            return visitorEntity;
        }

        public async Task<List<VisitorEntity>> GetAll()
        {
            var response = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.Active == true && q.Archive == false && q.Documentype == "visitor").ToList();
            return response;
        }

        public async Task<VisitorEntity> GetStudentByUId(string uid)
        {
            //  throw new NotImplementedException();
            var visitor = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false && q.Documentype == "visitor").FirstOrDefault();

            if(visitor==null)
            {
                return null;
            }
            else
            {
                return visitor;
            }
        }

        public async Task<VisitorEntity> UpdateVisitor(VisitorDto visitorDto)
        {
            var response = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.UId == visitorDto.UId && q.Active == true && q.Archive == false && q.Documentype == "visitor").FirstOrDefault();
            response.Archive = true;
            response.Active = false;
            await _container.ReplaceItemAsync(response, response.Id);

            return response;
        }

        public async Task<VisitorEntity> Creat(VisitorEntity response)
        {
            response = await _container.CreateItemAsync(response);
            return response;
        }

        public async Task<VisitorEntity> Delete(string uid)
        {
            var response = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false && q.Documentype == "visitor").FirstOrDefault();
            response.Archive = true;
            response.Active = false;

            await _container.ReplaceItemAsync(response, response.Id);
            return response;
        }
    }
}
