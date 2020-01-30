using System;
using System.Collections.Generic;
using System.Text;

namespace WingsOn.Common.Exceptions
{
    public class DoubleBookingException : Exception
    {
        public DoubleBookingException(string message) : base(message) { }
        public DoubleBookingException() { }
    }
}
