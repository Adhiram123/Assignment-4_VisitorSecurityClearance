
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;

namespace Assignment_4_VisitorSecurityClearance.CosmosDb
{
    public interface IManagerCosmosDbService
    {
        Task<ManagerEntity> AddManager(ManagerEntity managerEntity);
        Task<ManagerEntity> Creat(ManagerEntity response);
        Task<ManagerEntity> Delete(string uid);
        Task<List<ManagerEntity>> GetAll();
        Task<ManagerEntity>GetManagerByUId(string uid);
        Task<ManagerEntity> UpdateManager(ManagerDto managerDto);
    }
}
