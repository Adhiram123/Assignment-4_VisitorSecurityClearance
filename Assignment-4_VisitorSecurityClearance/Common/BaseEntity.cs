using Assignment_4_VisitorSecurityClearance.Entites;
using Newtonsoft.Json;

namespace Assignment_4_VisitorSecurityClearance.Common
{
    public class BaseEntity
    {

        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]

        public string Id { get; set; }

        [JsonProperty(PropertyName = "uid", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "dtype", NullValueHandling = NullValueHandling.Ignore)]
        public string Documentype { get; set; }

        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updatedOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdON", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]

        public bool Active { get; set; }

        [JsonProperty(PropertyName = "archive", NullValueHandling = NullValueHandling.Ignore)]
        public bool Archive { get; set; }

        public static void intializer(bool isNew, string dtype, string createdOrUpdated, VisitorEntity student)
        {

            if (isNew)
            {
                student.Id = Guid.NewGuid().ToString();
                student.UId = student.Id;
                student.Documentype = dtype;
                student.CreatedBy = createdOrUpdated;
                student.CreatedOn = DateTime.Now;
                student.UpdatedBy = "";
                student.UpdatedOn = DateTime.Now;
                student.Version = 1;
                student.Active = true;
                student.Archive = false;
            }
            else
            {
                student.Id = Guid.NewGuid().ToString();

                student.Documentype = dtype;


                student.UpdatedBy = "createdOrUpdated";
                student.UpdatedOn = DateTime.Now;
                student.Version = 1;
                student.Active = true;
                student.Archive = false;
            }
        }

        public static void securityIntializer(bool isNew, string dtype, string createdOrUpdated, SecurityEntity student)
        {

            if (isNew)
            {
                student.Id = Guid.NewGuid().ToString();
                student.UId = student.Id;
                student.Documentype = dtype;
                student.CreatedBy = createdOrUpdated;
                student.CreatedOn = DateTime.Now;
                student.UpdatedBy = "";
                student.UpdatedOn = DateTime.Now;
                student.Version = 1;
                student.Active = true;
                student.Archive = false;
            }
            else
            {
                student.Id = Guid.NewGuid().ToString();

                student.Documentype = dtype;


                student.UpdatedBy = "createdOrUpdated";
                student.UpdatedOn = DateTime.Now;
                student.Version = 1;
                student.Active = true;
                student.Archive = false;
            }
        }
        public static void managerIntializer(bool isNew, string dtype, string createdOrUpdated, ManagerEntity init)
        {

            if (isNew)
            {
                init.Id = Guid.NewGuid().ToString();
                init.UId = init.Id;
                init.Documentype = dtype;
                init.CreatedBy = createdOrUpdated;
                init.CreatedOn = DateTime.Now;
                init.UpdatedBy = "";
                init.UpdatedOn = DateTime.Now;
                init.Version = 1;
                init.Active = true;
                init.Archive = false;
            }
            else
            {
                init.Id = Guid.NewGuid().ToString();

                init.Documentype = dtype;


                init.UpdatedBy = createdOrUpdated;
                init.UpdatedOn = DateTime.Now;
                init.Version = 1;
                init.Active = true;
                init.Archive = false;
            }
        }
        public static void officeIntializer(bool isNew, string dtype, string createdOrUpdated, OfficeEntity init)
        {

            if (isNew)
            {
                init.Id = Guid.NewGuid().ToString();
                init.UId = init.Id;
                init.Documentype = dtype;
                init.CreatedBy = createdOrUpdated;
                init.CreatedOn = DateTime.Now;
                init.UpdatedBy = "";
                init.UpdatedOn = DateTime.Now;
                init.Version = 1;
                init.Active = true;
                init.Archive = false;
            }
            else
            {
                init.Id = Guid.NewGuid().ToString();

                init.Documentype = dtype;


                init.UpdatedBy = createdOrUpdated;
                init.UpdatedOn = DateTime.Now;
                init.Version = 1;
                init.Active = true;
                init.Archive = false;
            }
        }
    }
}
