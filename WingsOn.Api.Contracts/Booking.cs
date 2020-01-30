using System;
using System.Collections.Generic;
using System.Text;

namespace WingsOn.Api.Contracts
{
    public class Booking
    {
        public string Number { get; set; }

        public IReadOnlyList<int> Passengers { get; set; }
    }
}
