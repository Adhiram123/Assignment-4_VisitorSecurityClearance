using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Assignment_4_VisitorSecurityClearance.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class OfficeController : Controller
    {
        public readonly IOfficeService _officeService;
        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterOfficer(OfficeDto officeDto)
        {
            var response = await _officeService.AddOfficer(officeDto);

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
        public async Task<IActionResult> GetOfficerByUid(String uid)
        {
            var response = await _officeService.GetOfficerByUId(uid);

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
        public async Task<IActionResult> UpdateDetailsOfOfficer(OfficeDto OfficeDto)
        {

            var response = await _officeService.UpdateOfficer(OfficeDto);

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
        public async Task<IActionResult> Delete(string uid)
        {
            var response = await _officeService.Delete(uid);

            return Ok("delete succserfully");
        }

    }
}
