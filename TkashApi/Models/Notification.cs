using System;
namespace TkashApi.Models
{
    public class Notification
    {
        public string notificationType { get; set; }
        public NotificationBody notificationBody { get; set; }
    }

    public class NotificationBody
    {
        public int transactionAmount { get; set; }
        public DateTime transactionDate { get; set; }
        public int transactionId { get; set; }
        public int transactionFee { get; set; }
        public long billerMsisdn { get; set; }
        public int billerId { get; set; }
        public int accountNumber { get; set; }
        public int accountBalance { get; set; }
        public int brandId { get; set; }
        public string brandName { get; set; }
        public string srcAccountName { get; set; }
        public long sourceMSISDN { get; set; }
        public string txnTime { get; set; }
        public int accBalance { get; set; }
        public int destinationFees { get; set; }
        public string destAccName { get; set; }
        public int accountId { get; set; }
        public string customersIDdocumentType { get; set; }
        public string customersIDdocumentNumber { get; set; }
    }


}
