using Newtonsoft.Json;
using RestSharp;

namespace Ecommerce.Integration.AuthorizarApi
{
    public class Authorizar
    {
        public string Operation { get; set; }
        private readonly RestClient _restClient;

        public Authorizar( string urlBase )
        {
            _restClient = new RestClient( urlBase );
        }

        public IRestResponse Send( object obj )
        {
            RestRequest request = new RestRequest( "CreditCardTransaction", Method.POST );

            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody( JsonConvert.SerializeObject( obj ) );

            return _restClient.Execute( request );
        }
    }
}
