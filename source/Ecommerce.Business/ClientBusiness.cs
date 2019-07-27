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
    }
}
