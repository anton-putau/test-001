using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Common.Exceptions;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Services
{
    public class BookingService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly FlightService _flightService;
        private readonly PersonService _personService;

        public BookingService(
            BookingRepository bookingRepository, 
            FlightService flightService,
            PersonService personService)
        {
            _bookingRepository = bookingRepository;
            _flightService = flightService;
            _personService = personService;
        }

        public Booking BookFlightForUser(string flightNumber, int personId)
        {
            var flight = _flightService.GetFlightByNumberOrThrow404(flightNumber);

            var newPassenger = _personService.GetPersonOrThrow404(personId);

            Random random = new Random();
            var id = random.Next(int.MinValue, int.MaxValue);

            var booking = new Booking
            {
                Id = id,
                Number = Guid.NewGuid().ToString(),
                Customer = newPassenger,
                Flight = flight,
                Passengers = new List<Domain.Person> { newPassenger },
                DateBooking = DateTime.UtcNow,
            };

            _bookingRepository.Save(booking);

            return booking;

        }
    }
}
