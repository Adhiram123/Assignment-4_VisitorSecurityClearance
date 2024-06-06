using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public interface LoginInterfaceCosmosDbService
    {
        Task<string> GetLogin(string uid);
    }
}
