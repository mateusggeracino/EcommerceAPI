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
            CheckParameter(client);

            if (client.Id > 0) { Update(client); }
            else { Insert(client); }

        }

        /// <summary>
        /// Verifica a os valores de Cliente
        /// </summary>
        /// <param name="client"></param>
        public void CheckParameter(Client client)
        {
            ClientExeption.When(string.IsNullOrEmpty(client.CustomerName), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.CustomerDocument), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.CustomerEmail), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.CustomerGender), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.CustomerAddress), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.CustomerType), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.CustomerTelephone), "Client Name is required");
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
