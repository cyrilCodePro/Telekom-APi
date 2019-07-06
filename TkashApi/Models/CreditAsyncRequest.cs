using System;
namespace TkashApi.Models
{
    public class CreditAsyncRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string msisdn { get; set; }
        public int amount { get; set; }
        public string brandId { get; set; }
        public string info1 { get; set; }
        public string info2 { get; set; }
        public string info3 { get; set; }
        public string externalRef { get; set; }
    }

}
