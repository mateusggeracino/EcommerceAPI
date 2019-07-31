using System;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Configuration;
using Ecommerce.Integration.AuthorizarApi.Interface;

namespace Ecommerce.Integration.AuthorizarApi
{
    public class Authorizar : IAuthorizar
    {
        public string Operation { get; set; }

        private readonly RestClient _restClient;
        public Authorizar( IConfiguration config )
        {
            _restClient = new RestClient( config.GetSection( "Authorizar" ).GetSection( "UrlBase" ).Value );
        }

        public IRestResponse Send( string endPoint, object obj )
        {
            RestRequest request = new RestRequest( endPoint, Method.POST );

            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody( JsonConvert.SerializeObject( obj ) );

            return _restClient.Execute( request );
        }
    }
}
