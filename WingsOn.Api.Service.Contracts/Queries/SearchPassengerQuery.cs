using WingsOn.Api.Service.Contracts;

namespace WingsOn.Api.Contracts
{
    public class SearchPassengerQuery
    {
        public SearchPassengerQuery(Gender gender)
        {
            Gender = gender;
        }

        public Gender? Gender { get; }
    }
}
