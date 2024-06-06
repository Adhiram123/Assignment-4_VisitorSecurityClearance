using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public interface ICosmosDbService
    {
        Task<VisitorEntity> AddVisitor(VisitorEntity visitorEntity);
        Task<VisitorEntity> Creat(VisitorEntity response);
        Task<List<VisitorEntity>> GetAll();
        Task<VisitorEntity> GetStudentByUId(string uid);
        Task<VisitorEntity> UpdateVisitor(VisitorDto visitorDto);

        Task<VisitorEntity> Delete(string uid);
    }

}
