using Biblioteca.Services.Models;
using Biblioteca.Services.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Web.API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomersService customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomersService customerService)
        {
            _logger = logger;
            this.customerService = customerService;
        }

        [Route("api/Customers")]
        [HttpGet]
        public IEnumerable<ClientModel> GetCustomers()
        {
            return customerService.GetClients();
        }

        [Route("api/Customers/{clientId}")]
        [HttpGet]
        public ClientModel GetCustomerById([FromRoute] Guid clientId)
        {
            return customerService.GetClientByID(clientId);
        }

        [Route("api/Customers")]
        [HttpPost]
        public ClientModel InsertCustomers([FromBody]ClientModel client)
        {
            return customerService.InsertClient(client);
        }

        [Route("api/Customers/{clientId}")]
        [HttpPut]
        public ClientModel UpdateCustomer([FromBody] ClientModel client, [FromRoute] Guid clientId)
        {
            return customerService.UpdateClient(clientId, client);
        }

        [Route("api/Customers/{clientId}")]
        [HttpDelete]
        public void DeleteCustomer([FromRoute] Guid clientId)
        {
            customerService.DeleteClient(clientId);
        }
    }
}
