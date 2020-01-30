using WingsOn.Api.Contracts;
using WingsOn.Api.Contracts.Converters;
using WingsOn.Common.Exceptions;
using WingsOn.Dal;

namespace WingsOn.Api.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;
        private readonly IEntityConverter<Domain.Person, Person> _personConverter;

        public PersonService(
            PersonRepository personRepository,
            IEntityConverter<Domain.Person, Person> personConverter)
        {
            _personRepository = personRepository;
            _personConverter = personConverter;
        }

        public Person GetPersonOrThrow404(int personId)
        {
            var person = GetPersonOrThrow404Internal(personId);

            return _personConverter.Convert(person);
        }

        public Person UpdatePersonAddress(int personId, string address)
        {
            var person = GetPersonOrThrow404Internal(personId);

            PersonValidationRules.ValidateAddress(personId, address);

            person.Address = address;

            _personRepository.Save(person);

            return _personConverter.Convert(person);
        }

        internal  Domain.Person GetPersonOrThrow404Internal(int personId)
        {
            var person = _personRepository.Get(personId);

            if (person == null)
            {
                throw new NotFoundException($"Person with id '{personId}' was not found");
            }

            return person;
        }
    }
}
