using System.Collections.Generic;
using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStockServices _stockServices;
        public StockController(IMapper mapper, IStockServices stockServices)
        {
            _mapper = mapper;
            _stockServices = stockServices;
        }

        [HttpGet]
        public ActionResult<List<StockViewModel>> GetAll()
        {
            var stockList = _stockServices.GetAll();
            return _mapper.Map<List<StockViewModel>>(stockList); ;
        }

        [HttpPost]
        public ActionResult Insert([FromBody] StockViewModel stock )
        {
            if (!ModelState.IsValid) return BadRequest(stock);

            _stockServices.Insert(_mapper.Map<Stock>(stock));
            return Ok();
        }

        [HttpDelete]
        public ActionResult Remove(int id)
        {
            _stockServices.Remove(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] StockViewModel stock)
        {
            if (!ModelState.IsValid) return BadRequest(stock);
            _stockServices.Update(_mapper.Map<Stock>(stock));

            return Ok();
        }
    }
}