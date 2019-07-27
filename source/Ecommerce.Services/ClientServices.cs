using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Business;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Services
{
    public class ClientServices
    {
        private readonly ClientBusiness _clientebusiness;
        private readonly IRepository<Client> _clienterepository;

        public ClientServices(ClientBusiness clientebusiness,IRepository<Client> clientrepository)
        {
            _clientebusiness = clientebusiness;
            _clienterepository = clientrepository;
        }

        public void ClientSave(Client client)
        {
            _clientebusiness.CheckClient(client);
        }

        public void ClientUpdate(Client client)
        {
            _clientebusiness.CheckClient(client);
        }

        public IEnumerable<Client> ClientGetAll()
        {
            return _clienterepository.GetAll();
        }

        public Client ClientGetById(int id)
        {
            return null; //_clienterepository.ExecuteQuery($"Select * From table where id = {id}");
        }
    }
}
