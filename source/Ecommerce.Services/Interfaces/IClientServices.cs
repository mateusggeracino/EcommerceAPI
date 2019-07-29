using Ecommerce.Domain.Models;
using System.Collections.Generic;

namespace Ecommerce.Services.Interfaces
{
    public interface IClientServices
    {
        void ClientSave( Client client );
        void ClientUpdate( Client client );
        IEnumerable<Client> ClientGetAll( );
        Client ClientGetById( int id );
    }
}