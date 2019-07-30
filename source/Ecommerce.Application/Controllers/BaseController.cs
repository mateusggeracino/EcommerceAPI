using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public ActionResult<string> Errors(IList<ValidationFailure> validationErrors)
        {
            var listErrors = new List<string>();
            foreach (var error in validationErrors)
            {
                listErrors.Add(error.ErrorMessage);
            }
            return Ok(listErrors);
        }
    }
}