using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class Login : Controller
    {
        public readonly LoginInterface _loginService;
        public Login(LoginInterface loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> UserLog(string uid)
        {
            var response = await _loginService.CheckLogin(uid);
            if(response !=null)
            {
                return Ok(response+" is eligble to enter the Block");
            }
            else
            {
                return Ok("no user id is present");
            }
            
        }
    }
}
