using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.CosmosDb;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Assignment_4_VisitorSecurityClearance.Interfaces;

namespace Assignment_4_VisitorSecurityClearance.Service
{
    public class OfficeService :IOfficeService
    {
        public readonly IOfficeCosmosDbService _officeCosmosDbService;
        public readonly ICosmosDbService _cosmosDbService;
        public  OfficeService(IOfficeCosmosDbService officeCosmosDbService, ICosmosDbService cosmosDbService)
        {
            _officeCosmosDbService = officeCosmosDbService;
            _cosmosDbService = cosmosDbService;
        }

        public async Task<OfficeDto> AddOfficer(OfficeDto officeDto)
        {
            OfficeEntity officeEntity = new OfficeEntity();
            officeEntity.OfficerId = officeDto.OfficerId;
            officeEntity.CompanyName = officeDto.CompanyName;
            officeEntity.Name = officeDto.Name;
            officeEntity.PhoneNumber = officeDto.PhoneNumber;
            officeEntity.Email = officeDto.Email;

            BaseEntity.officeIntializer(true, "office", "Adhiram", officeEntity);

            //now we have to fetch the detiails to check the email is present or not
            var ReciveData = await _officeCosmosDbService.GetAll();

            bool Ispresent = false;
            foreach (var email in ReciveData)
            {
                if (officeDto.Email == email.Email)
                {
                    Ispresent = true;
                }
            }
            //Now we have to add the data to database
            if (Ispresent == false)
            {
                var response = await _officeCosmosDbService.AddOfficer(officeEntity);

                var responseDto = new OfficeDto();

                response.OfficerId = responseDto.OfficerId;
                response.UId = responseDto.UId;
                responseDto.Name = response.Name;
                responseDto.PhoneNumber = response.PhoneNumber;
                responseDto.Email = response.Email;

                var ReciveVisitorDto = await _cosmosDbService.GetAll();
                foreach(var email in ReciveVisitorDto)
                {
                    string emailSubject = "Confirmation";
                    string username = officeDto.Name + " ";
                    string emailMessage = "Dear " + username + "\n" +
                                "We have recived you Regestrion of the visitor form .Thank you for Contacting us.\n" +
                                "Our team is approved your to visit the Specified company.\n"+
                                 "If you face any inconvenience You can cantact to my personal mail";
                    EmailSender emailSender = new EmailSender();
                    emailSender.SendEmail(emailSubject, officeDto.Email, username, emailMessage).Wait();
                }

                return responseDto;
            }
            else
            {
                return null;
            }

        }


        public async  Task<OfficeDto> GetOfficerByUId(string uid)
        {
            var response = await _officeCosmosDbService.GetOfficerByUId(uid);

            if (response != null)
            {
                OfficeDto officeDto = new OfficeDto();

                officeDto.UId = response.UId;
                officeDto.OfficerId = response.OfficerId;
                officeDto.Name = response.Name;
                officeDto.PhoneNumber = response.PhoneNumber;
                officeDto.Email = response.Email;

                return officeDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<OfficeDto> UpdateOfficer(OfficeDto officeDto)
        {
            var response = await _officeCosmosDbService.UpdateOffice(officeDto);

            // var response = await _cosmosDbService.UpdateStudent(studentModel);

            BaseEntity.officeIntializer(false, "office", "Adhiram", response);

            response.UId = officeDto.UId;
            response.OfficerId = officeDto.OfficerId;
            response.Name = officeDto.Name;
            response.PhoneNumber = officeDto.PhoneNumber;
            response.Email = officeDto.Email;

            // response = await _container.CreateItemAsync(response);
            response = await _officeCosmosDbService.Creat(response);

            //create response to return
            OfficeDto response1 = new OfficeDto();
            response1.UId = response.UId;
            response1.Name = response.Name;
            response.PhoneNumber = response.PhoneNumber;
            response.Email = response.Email;

            return response1;
        }
        public async Task<OfficeDto> Delete(string uid)
        {
            var response = await _officeCosmosDbService.Delete(uid);

            //  response = await _cosmosDbService.save(response);

            //Asign the mandatory Values
            response.Archive = true;
            response.Active = false;

            OfficeDto officeDto = new OfficeDto();
            officeDto.UId = response.UId;
            officeDto.Name = response.Name;
            officeDto.CompanyName = response.CompanyName;
            officeDto.PhoneNumber = response.PhoneNumber;
            officeDto.Email = response.Email;
            officeDto.OfficerId = response.OfficerId;
            return officeDto;
        }
    }
}
