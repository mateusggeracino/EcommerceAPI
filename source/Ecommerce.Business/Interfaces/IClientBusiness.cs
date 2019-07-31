using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Business.Interfaces
{
    public interface IClientBusiness
    {
        Client Insert(Client insert);
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        Client Update(Client client);
    }
}