using Assignment_4_VisitorSecurityClearance.Common;
using Newtonsoft.Json;

namespace Assignment_4_VisitorSecurityClearance.Entites
{
    public class ManagerEntity : BaseEntity
    {
        [JsonProperty(PropertyName = "mangerId", NullValueHandling = NullValueHandling.Ignore)]
        public string ManagerId { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]

        public string Name { get; set; }

        [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    }
}
