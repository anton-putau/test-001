using WingsOn.Domain;

namespace WingsOn.Api.Contracts
{
    public class SearchPassengerQuery
    {
        public SearchPassengerQuery(GenderType gender)
        {
            Gender = gender;
        }

        public GenderType? Gender { get; }
    }
}
