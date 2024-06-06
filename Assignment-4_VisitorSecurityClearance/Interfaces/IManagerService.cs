using Assignment_4_VisitorSecurityClearance.DTO;

namespace Assignment_4_VisitorSecurityClearance.Interfaces
{
    public interface IManagerService
    {
        Task<ManagerDto> AddManager(ManagerDto managerDto);
        Task<ManagerDto> Delete(string uid);
        Task<ManagerDto> GetManagerByUId(string uid);
        Task<ManagerDto> UpdateManager(ManagerDto managerDto);
    }
}
