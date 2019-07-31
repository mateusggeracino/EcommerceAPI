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
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IClientServices _clientservices;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientServices clientservices, IMapper mapper, ILogger<ClientController> logger)
        {
            _clientservices = clientservices;
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/client
        [HttpGet]
        public ActionResult<List<ClientViewModel>> GetAll()
        {
            try
            {
                _logger.LogInformation("Received post request");
                var clients = _clientservices.GetAll();
                return Ok(_mapper.Map<List<ClientViewModel>>(clients));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        // GET api/client/5
        [HttpGet("{id}")]
        public ActionResult<ClientViewModel> Get(int id)
        {
            var client = _mapper.Map<ClientViewModel>(_clientservices.GetById(id));
            return client;
        }

        // POST api/client
        [HttpPost]
        public ActionResult<string> Post([FromBody] ClientViewModel client)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(client);

                var clientEntity = _clientservices.Insert(_mapper.Map<Client>(client));
                if (clientEntity.ValidationResult.Errors.Any()) return AddValidationErrors(clientEntity.ValidationResult.Errors);

                return Ok("success");
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        // PUT api/client/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Client value)
        {
            value.Id = id;
            _clientservices.Update(value);
            return Ok();
        }

    }
}