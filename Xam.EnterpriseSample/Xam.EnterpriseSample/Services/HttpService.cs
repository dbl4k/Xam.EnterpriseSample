using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Xam.EnterpriseSample.Services
{
    // singleton http instance wrapper
    class HttpService
    {
        private static readonly HttpClient _client = new HttpClient();

        public static HttpClient Client
        {
            get
            {
                return _client;
            }
        }

        public HttpService()
        {

        }
    }
}
