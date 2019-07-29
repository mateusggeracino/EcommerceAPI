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
            return _clientservices.GetAll().ToList();
        }

        // GET api/client/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            return _clientservices.GetById(id);
        }

        // POST api/client
        [HttpPost]
        public ActionResult<String> Post([FromBody] Client value)
        {
            _clientservices.Save(value);
            return Ok();
        }

        // PUT api/client/5
        [HttpPut("{id}")]
        public ActionResult<String> Put(int id, [FromBody] Client value)
        {
            value.Id = id;
            _clientservices.Update(value);
            return Ok();
        }

    }
}