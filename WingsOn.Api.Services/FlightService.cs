using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingsOn.Common.Exceptions;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Services
{
    public class FlightService
    {
        private readonly FlightRepository _flightRepository;
        private readonly BookingRepository _bookingRepository;

        public FlightService(FlightRepository flightRepository, BookingRepository bookingRepository)
        {
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
        }

        public IReadOnlyList<Person> GetFlightPassengersByNumber(string flightNumber)
        {
            GetFlightByNumberOrThrow404(flightNumber);

            var bookings = _bookingRepository.GetBookingsForFlightNumber(flightNumber);

            return bookings.SelectMany(bk => bk.Passengers).ToList();
        }

        private Flight GetFlightByNumberOrThrow404(string flightNumber)
        {
            var flight = _flightRepository.GetByNumber(flightNumber);

            if(flight == null)
            {
                throw new NotFoundException($"Flight with number '{flightNumber}' was not found");
            }

            return flight;
        }
    }
}
