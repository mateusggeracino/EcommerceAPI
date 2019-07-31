using System.IO;
using Ecommerce.Integration.AuthorizarApi.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Ecommerce.Integration.AuthorizarApi.Business
{
    public class Integration<T> : IIntegration<T> where T : new()
    {
        private static IConfiguration Config => InitConfiguration();
        private readonly RestClient _restClient;
        public Integration()
        {
            _restClient = new RestClient(Config.GetSection("Authorizar").GetSection("UrlBase").Value);
        }

        public T Post(string endPoint, object obj)
        {
            var request = new RestRequest(endPoint, Method.POST)
            {
                RequestFormat = DataFormat.Json
            }.AddJsonBody(JsonConvert.SerializeObject(obj));
            
            var response = _restClient.Execute<T>(request);
            return response.Data;
        }

        private static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
    }
}