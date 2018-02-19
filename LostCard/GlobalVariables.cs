using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LostCard
{
    public static class GlobalVariables
    {
        public static HttpClient webApi = new HttpClient();
        
        static GlobalVariables()
        {
            webApi.BaseAddress = new Uri("http://localhost:52074/api/");
            webApi.DefaultRequestHeaders.Clear();
            webApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}