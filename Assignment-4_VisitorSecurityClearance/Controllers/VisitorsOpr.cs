using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Assignment_4_VisitorSecurityClearance.Controllers
{

    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class VisitorOpr : Controller
    {
        public readonly IVisitorService _visitorService;

        public VisitorOpr(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpPost]
        public async Task<IActionResult> Register_New_Visitor(VisitorDto visitorDto)
        {
            var response = await _visitorService.AddVisitor(visitorDto);
            if(response != null)
            {
                return Ok(response);
            }
            else
            {
                return Ok("Email is already in use");
            }
            

        }
        [HttpGet]
        public async Task<IActionResult> GetVisitorByUid(String uid)
        {
            var response = await _visitorService.GetStudentByUId(uid);

            if(response !=null)
            {
                return Ok(response);
            }
            else
            {
                return Ok("Enterd Id is Invalid");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDetailsOfVisitor(VisitorDto visitorDto)
        {

            var response = await _visitorService.UpdateVisitor(visitorDto);

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
        public async Task<IActionResult> DeleteVisitor(string uid)
        {
            var response = await _visitorService.Delete(uid);

            return Ok("delete succserfully");
        }
    }
}
