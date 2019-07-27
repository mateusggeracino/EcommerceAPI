using System.Collections.Generic;
using AutoMapper;
using Ecommerce.Application.ViewModels;
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
        public ActionResult<List<StockViewModel>> Get()
        {
            var stockList = _stockServices.GetAll();
            return _mapper.Map<List<StockViewModel>>(stockList);
        }

        [HttpPost]
        public ActionResult Insert([FromBody] StockViewModel stock )
        {
            return null;
        }
    }
}