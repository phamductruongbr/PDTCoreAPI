using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PDTCoreAPI.UserClient
{
    public class ClientConfiguration
    {
        public static HttpClient WebApiClient = new HttpClient();
        static ClientConfiguration()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44324/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}