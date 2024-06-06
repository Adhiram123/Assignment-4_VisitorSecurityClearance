using Assignment_4_VisitorSecurityClearance.DTO;

namespace Assignment_4_VisitorSecurityClearance.Interfaces
{
    public interface IOfficeService
    {
        Task<OfficeDto> AddOfficer(OfficeDto officeDto);
        Task<OfficeDto> Delete(string uid);
        Task<OfficeDto> GetOfficerByUId(string uid);
        Task<OfficeDto> UpdateOfficer(OfficeDto managerDto);
    }
}
