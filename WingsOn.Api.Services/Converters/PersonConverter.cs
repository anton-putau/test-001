using WingsOn.Api.Service.Contracts;

namespace WingsOn.Api.Contracts.Converters
{
    public class PersonConverter : IEntityConverter<Domain.Person, Contracts.Person>
    {
        public Contracts.Person Convert(Domain.Person domainEntity)
        {
            return new Contracts.Person
            {
                Gender = (Gender)(int)domainEntity.Gender,
                Name = domainEntity.Name,
                Email = domainEntity.Email,
                Address = domainEntity.Address,
                DateBirth = domainEntity.DateBirth
            };
        }
    }
}
