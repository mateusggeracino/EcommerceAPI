using Ecommerce.Domain.Models;
using System.Collections.Generic;

namespace Ecommerce.Services.Interfaces
{
    public interface IClientServices
    {
        Client Insert(Client client);

        Client Update(Client client);

        IEnumerable<Client> GetAll();

        Client GetById(int id);
    }
}