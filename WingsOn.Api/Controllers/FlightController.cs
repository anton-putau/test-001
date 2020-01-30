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
        private readonly BookingService _bookingService;
        private readonly IEntityConverter<Domain.Person, Person> _personConverter;
        private readonly IEntityConverter<Domain.Booking, Booking> _bookingConverter;

        public FlightController(
            FlightService flightService,
            BookingService bookingService,
            IEntityConverter<Domain.Person, Contracts.Person> personConverter,
            IEntityConverter<Domain.Booking, Contracts.Booking> bookingConverter)
        {
            _flightService = flightService;
            _bookingService = bookingService;
            _personConverter = personConverter;
            _bookingConverter = bookingConverter;
        }

        [HttpGet("{flightNumber}/passengers")]
        public ActionResult<IEnumerable<Person>> GetFlightPassengers(string flightNumber)
        {
            var passengers = _flightService.GetFlightPassengersByNumber(flightNumber);
            
            return passengers.Select(_personConverter.Convert).ToList();
        }

        [HttpPost("{flightNumber}/book/{personId}")]
        public ActionResult<Booking> BookNewPassenger(string flightNumber, int personId)
        {
            var booking = _bookingService.BookFlightForUser(flightNumber, personId);

            return _bookingConverter.Convert(booking);
        }
    }
}