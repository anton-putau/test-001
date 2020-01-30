using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingsOn.Api.Contracts;
using WingsOn.Api.Contracts.Converters;
using WingsOn.Dal;

namespace WingsOn.Api.Services
{
    public class SearchService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly IEntityConverter<Domain.Person, Person> _personConverter;

        public SearchService(BookingRepository bookingRepository, IEntityConverter<Domain.Person, Person> personConverter)
        {
            _bookingRepository = bookingRepository;
            _personConverter = personConverter;
        }

        public IReadOnlyList<Person> GetPassengers(SearchPassengerQuery query)
        {
            var passengersBuilder = new FilterBuilder<Domain.Person>();

            if (query.Gender.HasValue)
            {
                var gender = (Domain.GenderType)(int)query.Gender;
                passengersBuilder.AddExpression(ps => ps.Gender == gender);
            }

            var passengers = _bookingRepository.GetPassengersByFilter(passengersBuilder.Build());

            return passengers.Select(_personConverter.Convert).ToList();
        }
    }
}
