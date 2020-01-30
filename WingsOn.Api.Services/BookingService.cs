using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Api.Contracts;
using WingsOn.Api.Contracts.Converters;
using WingsOn.Common.Exceptions;
using WingsOn.Dal;

namespace WingsOn.Api.Services
{
    public class BookingService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly FlightService _flightService;
        private readonly PersonService _personService;
        private readonly IEntityConverter<Domain.Booking, Booking> _bookingConverter;

        public BookingService(
            BookingRepository bookingRepository, 
            FlightService flightService,
            PersonService personService,
            IEntityConverter<Domain.Booking, Booking> bookingConverter)
        {
            _bookingRepository = bookingRepository;
            _flightService = flightService;
            _personService = personService;
            _bookingConverter = bookingConverter;
        }

        public Booking BookFlightForUser(string flightNumber, int personId)
        {
            var flight = _flightService.GetFlightByNumberOrThrow404(flightNumber);

            var newPassenger = _personService.GetPersonOrThrow404Internal(personId);

            Random random = new Random();
            var id = random.Next(int.MinValue, int.MaxValue);

            var booking = new Domain.Booking
            {
                Id = id,
                Number = Guid.NewGuid().ToString(),
                Customer = newPassenger,
                Flight = flight,
                Passengers = new List<Domain.Person> { newPassenger },
                DateBooking = DateTime.UtcNow,
            };

            _bookingRepository.Save(booking);

            return _bookingConverter.Convert(booking);

        }
    }
}
