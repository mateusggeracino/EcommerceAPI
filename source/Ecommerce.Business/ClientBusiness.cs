using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Validations;
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

        public Client Insert(Client client)
        {
            var clientValidation = new ClientValidation();
            client.ValidationResult = clientValidation.Validate(client);

            if (client.ValidationResult.Errors.Any()) return client;

            return _clientRepository.Insert(client);
        }

        public Client Update(Client cliente)
        {
            return _clientRepository.Update(cliente);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);
        }
    }
}
