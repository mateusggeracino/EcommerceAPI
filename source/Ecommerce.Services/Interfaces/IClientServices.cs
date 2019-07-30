using Ecommerce.Domain.Models;
using System.Collections.Generic;

namespace Ecommerce.Services.Interfaces
{
    public interface IClientServices
    {
        void Save(Client client);

        void Update(Client client);

        IEnumerable<Client> GetAll();

        Client GetById(int id);
    }
}