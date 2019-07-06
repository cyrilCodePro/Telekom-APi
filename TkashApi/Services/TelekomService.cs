using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace TkashApi.Services
{

    public class TelekomService<T> : ITelekomService
    {

        private readonly T payload;
        private readonly string Url;
        private readonly Method method;
        private readonly Dictionary<string, string> Headers;

        public TelekomService(string url, Method _method, T _payload, Dictionary<string, string> _headers = null)
        {
            payload = _payload;
            Url = url;
            method = _method;
            Headers = _headers;
        }


        public (string, HttpStatusCode) ServiceRequest()
        {
            var client = new RestClient(Url);
            var request = new RestRequest(method);
            request.Parameters.Clear();
            if (Headers != null)
            {
                foreach (var item in Headers)
                {
                    request.AddHeader(item.Key, item.Value);
                }
            }
            request.RequestFormat = DataFormat.Json;
            if (payload != null)
            {
                Type type = payload.GetType();
                string name = type.Name;
                string classNamee = name[0].ToString().ToLower() + name.Substring(1, name.Length - 1);

                JObject jObject = new JObject
                {
                    {classNamee,JToken.FromObject(payload)}

                };
                request.AddParameter("application/json", jObject
                    , ParameterType.RequestBody);
            }
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return (response.Content, response.StatusCode);


        }
        public (string, HttpStatusCode) ServiceRequestSpecial()
        {
            var client = new RestClient(Url);
            var request = new RestRequest(method);
            request.Parameters.Clear();
            if (Headers != null)
            {
                foreach (var item in Headers)
                {
                    request.AddHeader(item.Key, item.Value);
                }
            }
            request.RequestFormat = DataFormat.Json;
            if (payload != null)
            {
                JObject jObject = JObject.FromObject(payload);
                request.AddParameter("application/json", jObject
                    , ParameterType.RequestBody);
            }
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            return (response.Content, response.StatusCode);


        }

    }

}
