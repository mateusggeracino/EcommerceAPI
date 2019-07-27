using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Business.Interfaces
{
    public interface IClientBusiness
    {
        void CheckClient(Client client);
        IEnumerable<Client> GetAll();

        Client GetById(int id);
    }
}