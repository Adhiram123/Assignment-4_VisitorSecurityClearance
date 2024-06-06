
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.Interfaces
{
    public interface LoginInterface
    {
        Task<string> CheckLogin(string uid);
    }
}
