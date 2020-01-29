using WingsOn.Common.Exceptions;
using WingsOn.Dal;

namespace WingsOn.Api.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;

        public PersonService(
            PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Domain.Person GetPersonOrThrow404(int personId)
        {
            var person = _personRepository.Get(personId);

            if (person == null)
            {
                throw new NotFoundException($"Person with id '{personId}' was not found");
            }

            return person;
        }

        public Domain.Person UpdatePersonAddress(int personId, string address)
        {
            var person = GetPersonOrThrow404(personId);

            PersonValidationRules.ValidateAddress(personId, address);

            person.Address = address;

            _personRepository.Save(person);

            return person;
        }
    }
}
