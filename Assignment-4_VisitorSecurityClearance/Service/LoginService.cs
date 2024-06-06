using Assignment_4_VisitorSecurityClearance.CosmosDb;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.Service
{
    public class LoginService : LoginInterface
    {
        public readonly LoginInterfaceCosmosDbService _loginInterface;
        public LoginService(LoginInterfaceCosmosDbService loginInterface)
        {
            _loginInterface = loginInterface;
        }

        public async Task<string> CheckLogin(string uid)
        {
            var response = await _loginInterface.GetLogin(uid);
            return response;
        }
    }
}
