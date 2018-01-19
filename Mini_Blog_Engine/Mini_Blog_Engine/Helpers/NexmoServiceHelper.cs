using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Mini_Blog_Engine.Helpers
{
    public static class NexmoServiceHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static void SendTokenSMS(int secretNumber, string phonenumber)
        {
            string apiKey = WebConfigurationManager.AppSettings["Nexmo_Api_Key"];
            string apiSecret = WebConfigurationManager.AppSettings["Nexmo_Api_Secret"];
            var request = (HttpWebRequest)WebRequest.Create("https://rest.nexmo.com/sms/json");

            string nexmoPostData = "api_key=" + apiKey;
            nexmoPostData += "&api_secret=" + apiSecret;
            nexmoPostData += "&to=" + phonenumber;
            nexmoPostData += "&from=\"\"Blog M183\"\"";
            nexmoPostData += "&text=\"Hello, your secret number, for login is: " + secretNumber;

            var data = Encoding.ASCII.GetBytes(nexmoPostData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            // Todo Check Response
        }


    }
}