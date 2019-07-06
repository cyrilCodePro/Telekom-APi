using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TkashApi.Models;

namespace TkashApi.Services
{
    public class Telekom : ITelekom
    {
        private readonly string consumerKey;
        private readonly string consumerSecret;
        private readonly string BASE_URL = "https://api.telkom.co.ke/";

        public Telekom(string _consumerKey,string _consumerSecret,bool IsSandBox=false)
        {
            consumerKey = _consumerKey;
            consumerSecret = _consumerSecret;
            BASE_URL = IsSandBox == true ? "https://preprod.gw.mfs-tkl.com" : BASE_URL;
        }

        public string accessToken()
        {

            string url = BASE_URL + "token?grant_type=client_credentials";
            string test = $"{consumerKey}:{consumerSecret}";
            test = test.ToBase64();
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Basic {test}" }
            };

            ITelekomService service = new TelekomService<object>(url, RestSharp.Method.POST, null, headers);
            var item = service.ServiceRequestSpecial();
            TokenAcces post = JsonConvert.DeserializeObject<TokenAcces>(item.Item1);
            string token = post.access_token;
            post.access_token = token.Replace("'", " ");
            post.access_token = post.access_token.Trim();
            return post.access_token;
        }

        public string RegisterUrl(RegisterUrlRequest payload)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken().Trim()}" }
            };
            string url = BASE_URL + "consumer/v3/registerurl";
            ITelekomService service = new TelekomService<RegisterUrlRequest>(url, RestSharp.Method.POST, payload, headers);
            var item = service.ServiceRequest();
            return item.Item1;
        }

        public string UpdateUrl(UpdateUrlRequest payload)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken().Trim()}" }
            };
            string url = BASE_URL + "update-consumer/v3/updateUrl";
            ITelekomService service = new TelekomService<UpdateUrlRequest>(url, RestSharp.Method.PUT, payload, headers);
            var item = service.ServiceRequest();
            return item.Item1;
        }
        public string RegistrationRequest(RegistrationRequest payload)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken().Trim()}" }
            };
            string url = BASE_URL + "serviceRegistration/v3/register";
            ITelekomService service = new TelekomService<RegistrationRequest>(url, RestSharp.Method.POST, payload, headers);
            var item = service.ServiceRequest();
            return item.Item1;
        }

        public string AtpRequest(AtpRequest payload)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken().Trim()}" }
            };
            string url = "https://api.telkom.co.ke/tkash/airtimerequest/v3/atpAsync";
            ITelekomService service = new TelekomService<AtpRequest>(url, RestSharp.Method.POST, payload, headers);
            var item = service.ServiceRequest();
            return item.Item1;
        }
        public string Transaction(TransactionRequest payload)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken().Trim()}" }
            };
            string url = $@"https://api.telkom.co.ke/tkash/transactionstatus/v3/getstatus?referenceCode={payload.referenceCode}&transactionType={payload.transactionType}";
            ITelekomService service = new TelekomService<object>(url, RestSharp.Method.GET, null, headers);
            var item = service.ServiceRequest();
            return item.Item1;
        }

        public string ReplyNotification(ReplayNotification payload)
        {
            string url = $@"https://api.telkom.co.ke/notificationReplay/v3/replayNotification?notificationType={payload.notificationType}&id={payload.consumerID}&limit={payload.notificationCount}";
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken().Trim()}" }
            };
            ITelekomService service = new TelekomService<object>(url, RestSharp.Method.GET, null, headers);
            var item = service.ServiceRequest();
            return item.Item1;
        }

        public string B2C(CreditAsyncRequest payload)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken().Trim()}" }
            };
            string url = "https://api.telkom.co.ke/tkash/b2c/v3/async";
            ITelekomService service = new TelekomService<CreditAsyncRequest>(url, RestSharp.Method.POST, payload, headers);
            var item = service.ServiceRequest();
            return item.Item1;
        }

        public string C2B(C2BSimulate payload)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {accessToken().Trim()}" }
            };
            string url = $@"https://api.telkom.co.ke/simulate/v3/c2b/{payload.BillerId}";
            ITelekomService service = new TelekomService<object>(url, RestSharp.Method.GET, null, headers);
            var item = service.ServiceRequest();
            return item.Item1;

        }

    }
}
