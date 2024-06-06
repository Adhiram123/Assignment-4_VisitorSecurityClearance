using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.CosmosDb;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Microsoft.OpenApi.Validations;

namespace Assignment_4_VisitorSecurityClearance.Service
{
    public class SecurityService :ISecurityService
    {
        public readonly ISecurityCosmosDbService _securityCosmosDbService;
        public SecurityService(ISecurityCosmosDbService securityCosmosDbService)
        {
            _securityCosmosDbService = securityCosmosDbService;
        }

        public async Task<SecurityDto> AddSecurity(SecurityDto securityDto)
        {
            SecurityEntity securityEntity = new SecurityEntity();
            securityEntity.SecurityId = securityDto.SecurityId;
            securityEntity.Name = securityDto.Name;
            securityEntity.PhoneNumber = securityDto.PhoneNumber;
            securityEntity.Email = securityDto.Email;

            BaseEntity.securityIntializer(true, "security", "Adhiram",securityEntity);

            //now we have to fetch the detiails to check the email is present or not
            var ReciveData = await _securityCosmosDbService.GetAll();

            bool Ispresent = false;
            foreach (var email in ReciveData)
            {
                if (securityDto.Email == email.Email)
                {
                    Ispresent = true;
                }
            }
            //Now we have to add the data to database
            if (Ispresent == false)
            {
                var response = await _securityCosmosDbService.AddSecurity(securityEntity);

                var responseDto = new SecurityDto();

                response.SecurityId = responseDto.SecurityId;
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

       

        public async Task<SecurityDto> GetSecurityByUId(string uid)
        {
            // throw new NotImplementedException();
            var response = await _securityCosmosDbService.GetSecurityByUId(uid);

            if (response != null)
            {
                SecurityDto securityDto = new SecurityDto();

                securityDto.UId = response.UId;
                securityDto.Name = response.Name;
                securityDto.PhoneNumber = response.PhoneNumber;
                securityDto.Email = response.Email;

                return securityDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<SecurityDto> UpdateSecurity(SecurityDto securityDto)
        {
            //throw new NotImplementedException();
            var response = await _securityCosmosDbService.UpdateSecurity(securityDto);

            // var response = await _cosmosDbService.UpdateStudent(studentModel);

            BaseEntity.securityIntializer(false, "security", "Adhiram", response);
            response.UId = securityDto.UId;
            response.SecurityId= securityDto.SecurityId;
            response.Name = securityDto.Name;
            response.PhoneNumber = securityDto.PhoneNumber;
            response.Email = securityDto.Email;

            // response = await _container.CreateItemAsync(response);
            response = await _securityCosmosDbService.Creat(response);

            //create response to return
            SecurityDto response1 = new SecurityDto();
            response1.UId = response.UId;
            response1.Name = response.Name;
            response.PhoneNumber = response.PhoneNumber;
            response.Email = response.Email;

            return response1;
        }

        public async Task<SecurityDto> Delete(string uid)
        {
            var response = await _securityCosmosDbService.Delete(uid);

            //  response = await _cosmosDbService.save(response);

            //Asign the mandatory Values
            response.Archive = true;
            response.Active = false;

            SecurityDto securityDto = new SecurityDto();
            securityDto.UId = response.UId;
            securityDto.Name = response.Name;
            securityDto.PhoneNumber = response.PhoneNumber;
            securityDto.Email = response.Email;
            securityDto.SecurityId = response.SecurityId;
            return securityDto;
        }
    }
}
