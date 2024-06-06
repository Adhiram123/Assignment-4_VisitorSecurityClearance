
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.Interfaces
{
    public interface IVisitorService
    {
        Task<VisitorDto> AddVisitor(VisitorDto visitorDto);
        Task<VisitorDto> GetStudentByUId(string uid);
        Task<VisitorDto> UpdateVisitor(VisitorDto visitorDto);

        Task<VisitorDto> Delete(string uid);
    }
}
