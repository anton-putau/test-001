using System;
using WingsOn.Domain;

namespace WingsOn.Api.Contracts
{
    public class Person
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public GenderType Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
