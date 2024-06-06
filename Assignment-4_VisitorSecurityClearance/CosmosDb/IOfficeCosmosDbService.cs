
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public interface IOfficeCosmosDbService
    {
        Task<OfficeEntity> AddOfficer(OfficeEntity officeEntity);
        Task<OfficeEntity> Creat(OfficeEntity response);
        
        Task<List<OfficeEntity>> GetAll();
        Task<OfficeEntity> GetOfficerByUId(string uid);
        Task<OfficeEntity> UpdateOffice(OfficeDto officeDto);
        Task<OfficeEntity> Delete(string uid);
    }
}
