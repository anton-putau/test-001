using System.Collections.Generic;

namespace WingsOn.Api.Contracts
{
    public class Booking
    {
        public string Number { get; set; }

        public IReadOnlyList<int> Passengers { get; set; }
    }
}
