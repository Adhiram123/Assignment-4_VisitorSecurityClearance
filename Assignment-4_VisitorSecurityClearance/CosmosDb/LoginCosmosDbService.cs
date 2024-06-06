using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public class LoginCosmosDbService :LoginInterfaceCosmosDbService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;
        public LoginCosmosDbService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndPoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }

        public async Task<string> GetLogin(string uid)
        {
            var response =  _container.GetItemLinqQueryable<OfficeEntity>(true).Where(q => q.UId == uid && q.Active == true && q.Archive == false &&( q.Documentype=="office" || q.Documentype=="visitor"||q.Documentype=="manager")).FirstOrDefault();
           // string name = response.Name;
            return  response.Name;
        }
    }
}
