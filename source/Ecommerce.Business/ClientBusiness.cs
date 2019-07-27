using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Business
{

    public class ClientBusiness
    {
        private readonly IRepository<Client> _clienterepository;

        public ClientBusiness(IRepository<Client> clienterepository)
        {
            _clienterepository = clienterepository;
        }

        private void Insert(Client cliente)
        {
            _clienterepository.Insert(cliente);
        }

        private void Update(Client cliente)
        {
            _clienterepository.Update(cliente);
        }

        public void CheckClient(Client client)
        {
            if (client.Id == null)
            {
                Insert(client);
            }
            else
            {
                Update(client);
            }

        }


    }
}
