using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Assignment_4_VisitorSecurityClearance.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class ManagerController : Controller
    {
        public readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterManager(ManagerDto managerDto)
        {
            var response = await _managerService.AddManager(managerDto);

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
        public async Task<IActionResult> GetManagerByUid(String uid)
        {
            var response = await _managerService.GetManagerByUId(uid);

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
        public async Task<IActionResult> UpdateDetailsOfManager(ManagerDto managerDto)
        {

            var response = await _managerService.UpdateManager(managerDto);

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
        public async Task<IActionResult> DeleteManager(string uid)
        {
            var response = await _managerService.Delete(uid);

            return Ok("delete succserfully");
        }

    }
}
