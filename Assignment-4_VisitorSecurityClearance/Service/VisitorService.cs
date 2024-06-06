using Assignment_4_VisitorSecurityClearance.Common;
using Assignment_4_VisitorSecurityClearance.CosmosDb;
using Assignment_4_VisitorSecurityClearance.DTO;
using Assignment_4_VisitorSecurityClearance.Entites;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Assignment_4_VisitorSecurityClearance.Service
{
    public class VisitorService : IVisitorService
    {
        public readonly ICosmosDbService _cosmosDbService;
        public readonly IOfficeCosmosDbService _officeCosmosDbService;

        public VisitorService(ICosmosDbService cosmosDbService, IOfficeCosmosDbService officeCosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
            _officeCosmosDbService = officeCosmosDbService;
        }

        public async  Task<VisitorDto> AddVisitor(VisitorDto visitorDto)
        {
            VisitorEntity visitorEntity =new VisitorEntity();
            visitorEntity.Name = visitorDto.Name;
            visitorEntity.PhoneNumber = visitorDto.PhoneNumber;

            visitorEntity.CompanyName = visitorDto.CompanyName;
            visitorEntity.Email = visitorDto.Email;



            BaseEntity.intializer(true, "visitor", "Adhiram", visitorEntity);

            //now we have to fetch the detiails to check the email is present or not
            var ReciveData = await _cosmosDbService.GetAll();

            
            bool Ispresent = false;
            foreach (var email in ReciveData)
            {
              if(visitorDto.Email == email.Email)
                {
                    Ispresent = true;
                }
            }

            //Now we have to add the StudentEntity in DataBase
            if (Ispresent==false)
            {
                var response = await _cosmosDbService.AddVisitor(visitorEntity);


                var responseDto = new VisitorDto();

                response.UId = responseDto.UId;
                responseDto.Name = response.Name;
                responseDto.CompanyName = response.CompanyName;
                responseDto.PhoneNumber = response.PhoneNumber;
                responseDto.Email = response.Email;
                responseDto.Purpose = response.Purpose;
                /*string emailSubject = "Confirmation";
                string username = visitorDto.Name + " ";
                string emailMessage = "Dear " + username + "\n" +
                            "We have recived you Regestrion of the visitor form .Thank you for Contacting us.\n" +
                            "Our team is approved your to visit the " + visitorDto.CompanyName;
                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail(emailSubject, visitorDto.Email, username, emailMessage).Wait();*/
                var ReciveOfficeDto = await _officeCosmosDbService.GetAll();
                foreach(var email in ReciveOfficeDto)
                {
                    string emailSubject = "Confirmation";
                    string username = visitorDto.Name + " ";
                    string emailMessage = "Dear " + email.Name + "\n" +
                                "New Visitor has  register thorugh Security Personal to enter into the business block.\n" +
                                "So please review and  permision to enter into the block to visit " + visitorDto.CompanyName +" company"+
                                 " the purpose is "+responseDto.Purpose;
                    EmailSender emailSender = new EmailSender();
                    emailSender.SendEmail(emailSubject, visitorDto.Email, username, emailMessage).Wait();
                }



                return responseDto;
            }
            else
            {
                return null;
            }

        }


        public  async Task<VisitorDto> GetStudentByUId(string uid)
        {
            // throw new NotImplementedException();
            var response = await _cosmosDbService.GetStudentByUId(uid);
            if (response != null)
            {
                VisitorDto visitorDto = new VisitorDto();

                visitorDto.UId = response.UId;
                visitorDto.Name = response.Name;
                visitorDto.PhoneNumber = response.PhoneNumber;
                visitorDto.Email = response.Email;

                return visitorDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<VisitorDto> UpdateVisitor(VisitorDto visitorDto)
        {
            //throw new NotImplementedException();
            var response = await  _cosmosDbService.UpdateVisitor(visitorDto);

            // var response = await _cosmosDbService.UpdateStudent(studentModel);

            BaseEntity.intializer(false, "visitor", "Adhiram",response);
            response.UId = visitorDto.UId;
            response.Name = visitorDto.Name;
            response.PhoneNumber = visitorDto.PhoneNumber;
            response.Email = visitorDto.Email;

            // response = await _container.CreateItemAsync(response);
            response = await _cosmosDbService.Creat(response);

            //create response to return
            VisitorDto response1 = new VisitorDto();
            response1.UId = response.UId;
            response1.Name = response.Name;
            response.PhoneNumber = response.PhoneNumber;
            response.Email = response.Email;

            return response1;

        }

        public async Task<VisitorDto> Delete(string uid)
        {
            var response = await _cosmosDbService.Delete(uid);

            //  response = await _cosmosDbService.save(response);

            //Asign the mandatory Values
            response.Archive = true;
            response.Active = false;

            VisitorDto visitor = new VisitorDto();
            visitor.UId = response.UId;
            visitor.Name = response.Name;
            visitor.PhoneNumber = response.PhoneNumber;
            visitor.Email = response.Email;
            return visitor;
        }
    }
}
