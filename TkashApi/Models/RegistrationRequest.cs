using System;
namespace TkashApi.Models
{
    public class RegistrationRequest
    {
        public string shortCode { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string serviceId { get; set; }
        public string ussdLevel { get; set; }
        public string email { get; set; }
    }

}
