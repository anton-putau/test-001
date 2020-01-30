using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingsOn.Api.Contracts;
using WingsOn.Dal;

namespace WingsOn.Api.Services
{
    public class SearchService
    {
        private readonly BookingRepository _bookingRepository;

        public SearchService(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IReadOnlyList<Domain.Person> GetPassengers(SearchPassengerQuery query)
        {
            var passengersBuilder = new FilterBuilder<Domain.Person>();

            if (query.Gender.HasValue)
            {
                passengersBuilder.AddExpression(ps => ps.Gender == query.Gender.Value);
            }

            var passengers = _bookingRepository.GetPassengersByFilter(passengersBuilder.Build());

            return passengers;
        }
    }
}
