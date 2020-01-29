using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Contracts;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}/address")]
        public void UpdatePassengerAddress(int id, [FromBody] string newAddress)
        {
            throw new NotImplementedException();
        }
    }
}
