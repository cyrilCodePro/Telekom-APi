using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TkashApi.Services
{
    public class TokenAcces
    {
        public string access_token { get; set; }

    }

    public static class Common
    {
        public static string ToBase64(this string text)
        {
            return ToBase64(text, Encoding.UTF8);
        }
       
        public static string ToBase64(this string text, Encoding encoding)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            byte[] textAsBytes = encoding.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }
    }

}
