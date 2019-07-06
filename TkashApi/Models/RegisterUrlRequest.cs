using System;
namespace TkashApi.Models
{
    public class RegisterUrlRequest
    {
        public string consumerId { get; set; }
        public string notificationUrl { get; set; }
        public string notificationUrlType { get; set; }
        public string validationUrl { get; set; }
        public string validationUrlType { get; set; }
        public string creationDate { get; set; }
    }


}
