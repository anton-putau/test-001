namespace WingsOn.Api.Contracts.Converters
{
    public interface IEntityConverter<T, K>
    {
        K Convert(T domainEntity);
    }
}
