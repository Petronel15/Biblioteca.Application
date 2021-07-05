using Biblioteca.Core.Data;
using Biblioteca.Services.Automapper;
using Biblioteca.Services.Models;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Core.DomainModels;
using Biblioteca.Services.Services.CustomerService;
using System;

namespace Biblioteca.Services.Services.CustomerService
{
    public class CustomerService : ICustomersService
    {
        private readonly IRepository<Client> clientRepository;
        

        public CustomerService(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        

        public void DeleteClient(Guid clientId)
        {
            try
            {
                var client = clientRepository.GetById(clientId);
                if (client == null)
                {
                    throw new ArgumentException("Client ID is not found!");
                }
                clientRepository.Delete(client);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ClientModel GetClientByID(Guid clientId)
        {
            var client = clientRepository.Table.Where(x=>x.Id==clientId).FirstOrDefault();
            return client.ToModel();
        }

        public IEnumerable<ClientModel> GetClients()
        {
            var customers = clientRepository.Table.ToList();

            return customers.Select(c => c.ToModel()).ToList();
        }

        public ClientModel InsertClient(ClientModel client)
        {
            try
            {
                var entity = client.ToEntity();
                clientRepository.Insert(entity);
                return entity.ToModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ClientModel UpdateClient(Guid clientId, ClientModel client)
        {
            try
            {
                var entity = client.ToEntity();
                clientRepository.Update(entity);

                // return GetClientByID(clientId);
                return entity.ToModel();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // close connection
            }
        }

        
    }
}
