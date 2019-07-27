using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Business
{

    public class ClientBusiness : IClientBusiness
    {
        private readonly IClientRepository _clientRepository;

        public ClientBusiness(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        private void Insert(Client cliente)
        {
            _clientRepository.Insert(cliente);
        }

        private void Update(Client cliente)
        {
            _clientRepository.Update(cliente);
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

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
