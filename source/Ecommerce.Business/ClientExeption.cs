using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    class ClientExeption : Exception
    {
        public ClientExeption(string error) : base(error)
        {

        }
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new ClientExeption(error);
        }
    }
}
