using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IClientServices _clientservices;

        public ClientController(IClientServices clientservices, IMapper mapper)
        {
            _clientservices = clientservices;
            _mapper = mapper;
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
        public ActionResult<string> Post([FromBody] ClientViewModel client)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(client);

                var clientEntity = _clientservices.Insert(_mapper.Map<Client>(client));
                if (clientEntity.ValidationResult.Errors.Any()) return Errors(clientEntity.ValidationResult.Errors);

                return Ok("success");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
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