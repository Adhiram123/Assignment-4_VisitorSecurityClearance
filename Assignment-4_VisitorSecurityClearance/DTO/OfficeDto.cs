using Newtonsoft.Json;

namespace Assignment_4_VisitorSecurityClearance.DTO
{
    public class OfficeDto
    {
        [JsonProperty(PropertyName = "uid", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "officerId", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficerId { get; set; }

        [JsonProperty(PropertyName = "companyName", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]

        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "emailId", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }





    }
}
