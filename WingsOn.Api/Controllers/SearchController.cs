using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WingsOn.Api.Contracts;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        [HttpGet("passengers")]
        public ActionResult<IEnumerable<Person>> Get(SearchPassengerQuery searchParams)
        {
            throw new NotImplementedException();
        }
    }
}