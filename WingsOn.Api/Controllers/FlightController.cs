using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Contracts;

namespace WingsOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        [HttpGet("{flightNumber}/passengers")]
        public ActionResult<IEnumerable<Passenger>> GetFlightPassengers(string flightNumber)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{flightNumber}/book/{personId}")]
        public ActionResult<BookingConfirmation> BookNewPassenger(string flightNumber, int personId)
        {
            throw new NotImplementedException();
        }
    }
}