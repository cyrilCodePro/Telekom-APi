using System;
namespace TkashApi.Models
{
    public class AtpRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string msisdn { get; set; }
        public int amount { get; set; }
        public string brandId { get; set; }
    }

}
