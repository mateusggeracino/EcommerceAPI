using Ecommerce.Domain.Models;
using System.Collections.Generic;

namespace Ecommerce.Services.Interfaces
{
    public interface IClientServices
    {
<<<<<<< HEAD
        void Save(Client client);

        void Update(Client client);

        IEnumerable<Client> GetAll();

        Client GetById(int id);
=======
        void ClientSave( Client client );
        void ClientUpdate( Client client );
        IEnumerable<Client> ClientGetAll( );
        Client ClientGetById( int id );
>>>>>>> develop
    }
}