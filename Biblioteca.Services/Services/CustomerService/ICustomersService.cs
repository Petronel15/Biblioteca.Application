using Biblioteca.Services.Models;
using System;
using System.Collections.Generic;

namespace Biblioteca.Services.Services.CustomerService
{
    public interface ICustomersService
    {
        IEnumerable<ClientModel> GetClients();

        ClientModel GetClientByID(Guid clientId);

        ClientModel InsertClient(ClientModel client);

        ClientModel UpdateClient(Guid clientId, ClientModel client);

        void DeleteClient(Guid clientId);

        
    }
}
