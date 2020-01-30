using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WingsOn.Api.Contracts.Converters
{
    public class BookingConverter : IEntityConverter<Domain.Booking, Contracts.Booking>
    {
        public Contracts.Booking Convert(Domain.Booking domainEntity)
        {
            return new Contracts.Booking
            {
                Number = domainEntity.Number,
                Passengers = domainEntity.Passengers.Select(ps => ps.Id).ToList()
            };
        }
    }
}
