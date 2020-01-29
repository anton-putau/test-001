using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Contracts;
using WingsOn.Api.Contracts.Converters;
using WingsOn.Api.Services;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightService _flightService;
        private readonly IEntityConverter<Domain.Person, Person> _personConverter;

        public FlightController(
            FlightService flightService,
            IEntityConverter<Domain.Person, Contracts.Person> personConverter)
        {
            _flightService = flightService;
            _personConverter = personConverter;
        }

        [HttpGet("{flightNumber}/passengers")]
        public ActionResult<IEnumerable<Person>> GetFlightPassengers(string flightNumber)
        {
            var passengers = _flightService.GetFlightPassengersByNumber(flightNumber);
            
            return passengers.Select(_personConverter.Convert).ToList();
        }

        [HttpPost("{flightNumber}/book/{personId}")]
        public ActionResult<BookingConfirmation> BookNewPassenger(string flightNumber, int personId)
        {
            throw new NotImplementedException();
        }
    }
}