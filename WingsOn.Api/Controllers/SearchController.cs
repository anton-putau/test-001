using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Api.Contracts;
using WingsOn.Api.Contracts.Converters;
using WingsOn.Api.Services;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;
        private readonly IEntityConverter<Domain.Person, Person> _personConverter;

        public SearchController(
            SearchService searchService,
            IEntityConverter<Domain.Person, Contracts.Person> personConverter)
        {
            _searchService = searchService;
            _personConverter = personConverter;
        }

        [HttpGet("passengers/female")]
        public ActionResult<IEnumerable<Person>> GetFemalePassengers()
        {
            var passengers = _searchService.GetPassengers(new SearchPassengerQuery(Domain.GenderType.Female));

            return passengers.Select(_personConverter.Convert).ToList();
        }
    }
}