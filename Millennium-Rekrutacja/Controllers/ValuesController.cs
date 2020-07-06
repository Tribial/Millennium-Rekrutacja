using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Millennium_Rekrutacja.Common;
using Millennium_Rekrutacja.Common.Enums;
using Millennium_Rekrutacja.Dto;

namespace Millennium_Rekrutacja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse<T>(Result<T> result)
        {
            if (result.IsValid)
            {
                return Ok(result.Data);
            }

            switch (result.BusinessExceptionType)
            {
                case BusinessExceptionType.ArgumentError:
                    return BadRequest(result.Error);
                case BusinessExceptionType.NotFound:
                    return NotFound();
                case BusinessExceptionType.InternalServerError:
                default:
                    return BadRequest(Constants.Error.Default);
            }
        }
    }
}
