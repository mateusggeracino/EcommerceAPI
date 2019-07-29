using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientservices;

        public ClientController(IClientServices clientservices)
        {
            _clientservices = clientservices;
        }

        // GET api/client
        [HttpGet]
        public ActionResult <IEnumerable<Client>> GetAll()                                 
        {
            return _clientservices.ClientGetAll().ToList();
        }

        // GET api/client/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            return _clientservices.ClientGetById(id);
        }

        // POST api/client
        [HttpPost]
        public void Post([FromBody] Client value)
        {
            _clientservices.ClientSave(value);
        }

        // PUT api/client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Client value)
        {
            value.Id = id;
            _clientservices.ClientUpdate(value);
        }

    }
}