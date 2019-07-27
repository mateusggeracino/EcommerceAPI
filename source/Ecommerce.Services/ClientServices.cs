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

        public void ClientSave(Client client)
        {
            _clientBusiness.CheckClient(client);
        }

        public void ClientUpdate(Client client)
        {
            _clientBusiness.CheckClient(client);
        }

        public IEnumerable<Client> ClientGetAll()
        {
            return _clientBusiness.GetAll();
        }

        public Client ClientGetById(int id)
        {
            return null;
        }



    }
}
