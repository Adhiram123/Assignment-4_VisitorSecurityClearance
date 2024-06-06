using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;

namespace Assignment_4_VisitorSecurityClearance.Interfaces
{
    public interface ISecurityService
    {
        Task<SecurityDto> AddSecurity(SecurityDto securityDto);
        
        Task<SecurityDto> GetSecurityByUId(string uid);
        Task<SecurityDto> UpdateSecurity(SecurityDto securityDto);

        Task<SecurityDto> Delete(string uid);
    }
}
