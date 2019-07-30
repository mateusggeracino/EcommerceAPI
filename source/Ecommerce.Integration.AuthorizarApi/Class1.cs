using Newtonsoft.Json;
using RestSharp;
using System;
using Ecommerce.Integration.AuthorizarApi.Model;

namespace Ecommerce.Integration.AuthorizarApi
{
    public static class Class1
    {
        public static void teste( )
        {
            var client = new RestClient( "http://authorization-api.ddns.net:5000/api/v1/" );
            var request = new RestRequest( "CreditCardTransaction", Method.POST );

            request.RequestFormat = DataFormat.Json;

            var teste = new CreditCardTransaction( )
            {
                AmountInCents = 10000,
                CreateDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays( 5 ),
                HolderName = "Lucas Martins",
                Branch = "Pet",
                Number = "1",
                Reference = "",
                SecurityCode = "100"
            };

            request.AddJsonBody( JsonConvert.SerializeObject( teste ) );
            var response = client.Execute(request); 
        }

    }
}
