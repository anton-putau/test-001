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
        
        public FlightController(
            FlightService flightService,
            BookingService bookingService)
        {
            _flightService = flightService;
            _bookingService = bookingService;
        }

        [HttpGet("{flightNumber}/passengers")]
        public ActionResult<IEnumerable<Person>> GetFlightPassengers(string flightNumber)
        {
            return _flightService.GetFlightPassengersByNumber(flightNumber).ToList();
        }

        [HttpPost("{flightNumber}/book/{personId}")]
        public ActionResult<Booking> BookNewPassenger(string flightNumber, int personId)
        {
            return _bookingService.BookFlightForUser(flightNumber, personId);
        }
    }
}