using System;

namespace WingsOn.Common.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message): base(message){}
        public NotFoundException() { }
    }
}
