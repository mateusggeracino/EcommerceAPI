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
            ClientExeption.When(string.IsNullOrEmpty(client.Name), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.Document), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.Email), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.Gender), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.Address), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.Type), "Client Name is required");
            ClientExeption.When(string.IsNullOrEmpty(client.Telephone), "Client Name is required");
        }

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
