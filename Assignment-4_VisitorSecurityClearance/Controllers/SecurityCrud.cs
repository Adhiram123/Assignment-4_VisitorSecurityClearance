using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Assignment_4_VisitorSecurityClearance.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class SecurityCrud : Controller
    {
        public readonly ISecurityService _securityService;
        public SecurityCrud(ISecurityService securityService)
        {
            _securityService = securityService;
        }
       
        [HttpPost]
        public async Task<IActionResult> Register_New_SecurityPersonal(SecurityDto securityDto)
        {
            var response = await _securityService.AddSecurity(securityDto);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return Ok("Email is already in use");
            }


        }
        [HttpGet]
        public async Task<IActionResult> GetSecurityByUid(String uid)
        {
            var response = await _securityService.GetSecurityByUId(uid);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return Ok("Enterd Id is Invalid");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDetailsOfSecurity(SecurityDto securityDto)
        {

            var response = await _securityService.UpdateSecurity(securityDto);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return Ok("Enterd Id is Invalid");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSecurity(string uid)
        {
            var response = await _securityService.Delete(uid);

            return Ok("delete succserfully");
        }
    }
}
