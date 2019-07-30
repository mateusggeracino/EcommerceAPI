using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Integration.AuthorizarApi.Interface
{
    public interface IAuthorizar
    {
        IRestResponse Send( object obj );
    }
}
