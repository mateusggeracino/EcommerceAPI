using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/Client[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientServices _clientservices;

        public ClientController(ClientServices clientservices)
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
            _clientservices.ClientUpdate(value);
        }

    }
}