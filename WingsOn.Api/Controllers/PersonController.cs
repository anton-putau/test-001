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
        private readonly IEntityConverter<Domain.Person, Contracts.Person> _personConverter;


        public PersonController(
            PersonService personService, 
            IEntityConverter<Domain.Person, Contracts.Person> personConverter)
        {
            _personService = personService;
            _personConverter = personConverter;
        }

        [HttpGet("{personId}")]
        public ActionResult<Person> GetPerson(int personId)
        {
            var person = _personService.GetPersonOrThrow404(personId);

            return _personConverter.Convert(person);
        }

        [HttpPut("{personId}/address")]
        public void UpdatePassengerAddress(int personId, [FromBody] Contracts.Person person)
        {
            _personService.UpdatePersonAddress(personId, person.Address);
        }
    }
}
