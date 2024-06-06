
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public interface ISecurityCosmosDbService
    {
        Task<SecurityEntity> AddSecurity(SecurityEntity securityEntity);
        
        Task<List<SecurityEntity>> GetAll();
        Task<SecurityEntity> GetSecurityByUId(string uid);
        Task<SecurityEntity> UpdateSecurity(SecurityDto securityDto);

        Task<SecurityEntity> Creat(SecurityEntity response);
        Task<SecurityEntity> Delete(string uid);
    }
}
