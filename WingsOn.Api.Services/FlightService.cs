using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingsOn.Api.Contracts;
using WingsOn.Api.Contracts.Converters;
using WingsOn.Common.Exceptions;
using WingsOn.Dal;

namespace WingsOn.Api.Services
{
    public class FlightService
    {
        private readonly FlightRepository _flightRepository;
        private readonly BookingRepository _bookingRepository;
        private readonly IEntityConverter<Domain.Person, Person> _personConverter;

        public FlightService(
            FlightRepository flightRepository, 
            BookingRepository bookingRepository,
            IEntityConverter<Domain.Person, Person> personConverter)
        {
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
            _personConverter = personConverter;
        }

        public IReadOnlyList<Person> GetFlightPassengersByNumber(string flightNumber)
        {
            GetFlightByNumberOrThrow404(flightNumber);

            var bookings = _bookingRepository.GetBookingsForFlightNumber(flightNumber);

            return bookings.SelectMany(bk => bk.Passengers).Select(_personConverter.Convert).ToList();
        }

        internal Domain.Flight GetFlightByNumberOrThrow404(string flightNumber)
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
