using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Business;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IClientBusiness _clientBusiness;
        public ClientServices(IClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }

        public Client Insert(Client client)
        {
            return _clientBusiness.Insert(client);
        }

        public Client Update(Client client)
        {
            return _clientBusiness.Update(client);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientBusiness.GetAll();
        }

        public Client GetById(int id)
        {
            return _clientBusiness.GetById(id);
        }
    }
}
