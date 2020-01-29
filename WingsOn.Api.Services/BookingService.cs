using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Services
{
    public class BookingService
    {
        private readonly BookingRepository _bookingRepository;

        public BookingService(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
    }
}
