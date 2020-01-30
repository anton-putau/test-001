using System;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Contracts;
using WingsOn.Api.Contracts.Converters;
using WingsOn.Api.Services;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
   
        public PersonController(
            PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{personId}")]
        public ActionResult<Person> GetPerson(int personId)
        {
            return _personService.GetPersonOrThrow404(personId);
        }

        [HttpPut("{personId}/address")]
        public void UpdatePassengerAddress(int personId, [FromBody] Person person)
        {
            _personService.UpdatePersonAddress(personId, person.Address);
        }
    }
}
