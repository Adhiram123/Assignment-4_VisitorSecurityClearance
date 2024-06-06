using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.CosmosDb;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using System.Security.Policy;

namespace Assignment_4_VisitorSecurityClearance.Service
{
    public class ManagerService :IManagerService
    {

        public readonly IManagerCosmosDbService _managerCosmosDbService;
        public ManagerService(IManagerCosmosDbService managerCosmosDbService)
        {
            _managerCosmosDbService = managerCosmosDbService;
        }

        public async  Task<ManagerDto> AddManager(ManagerDto managerDto)
        {
            ManagerEntity managerEntity = new ManagerEntity();
            managerEntity.ManagerId = managerDto.ManagerId;
            managerEntity.Name = managerDto.Name;
            managerEntity.PhoneNumber = managerDto.PhoneNumber;
            managerEntity.Email = managerDto.Email;

            BaseEntity.managerIntializer(true, "manager", "Adhiram", managerEntity);

            //now we have to fetch the detiails to check the email is present or not
            var ReciveData = await _managerCosmosDbService.GetAll();

            bool Ispresent = false;
            foreach (var email in ReciveData)
            {
                if (managerDto.Email == email.Email)
                {
                    Ispresent = true;
                }
            }
            //Now we have to add the data to database
            if (Ispresent == false)
            {
                var response = await _managerCosmosDbService.AddManager(managerEntity);

                var responseDto = new ManagerDto();

                response.ManagerId = responseDto.ManagerId;
                response.UId = responseDto.UId;
                responseDto.Name = response.Name;
                responseDto.PhoneNumber = response.PhoneNumber;
                responseDto.Email = response.Email;

                return responseDto;
            }
            else
            {
                return null;
            }
        }

        

        public async Task<ManagerDto> GetManagerByUId(string uid)
        {
            var response = await _managerCosmosDbService.GetManagerByUId(uid);

            if (response != null)
            {
                ManagerDto managerDto = new ManagerDto();

                managerDto.UId = response.UId;
                managerDto.ManagerId = response.ManagerId;
                managerDto.Name = response.Name;
                managerDto.PhoneNumber = response.PhoneNumber;
                managerDto.Email = response.Email;

                return managerDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<ManagerDto> UpdateManager(ManagerDto managerDto)
        {
            var response = await _managerCosmosDbService.UpdateManager(managerDto);

            // var response = await _cosmosDbService.UpdateStudent(studentModel);

            BaseEntity.managerIntializer(false, "manager", "Adhiram", response);

            response.UId = managerDto.UId;
            response.ManagerId = managerDto.ManagerId;
            response.Name = managerDto.Name;
            response.PhoneNumber = managerDto.PhoneNumber;
            response.Email = managerDto.Email;

            // response = await _container.CreateItemAsync(response);
            response = await _managerCosmosDbService.Creat(response);

            //create response to return
            ManagerDto response1 = new ManagerDto();
            response1.UId = response.UId;
            response1.Name = response.Name;
            response.PhoneNumber = response.PhoneNumber;
            response.Email = response.Email;

            return response1;
        }

        public async  Task<ManagerDto> Delete(string uid)
        {
            var response = await _managerCosmosDbService.Delete(uid);

            //  response = await _cosmosDbService.save(response);

            //Asign the mandatory Values
            response.Archive = true;
            response.Active = false;

            ManagerDto managerDto = new ManagerDto();
            managerDto.UId = response.UId;
            managerDto.Name = response.Name;
            managerDto.PhoneNumber = response.PhoneNumber;
            managerDto.Email = response.Email;
            managerDto.ManagerId = response.ManagerId;
            return managerDto;
        }
    }
}
