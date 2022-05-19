namespace ConsoleApp
{
    public interface IDomainEvent
    {
        Guid EventId { get; }
        long AggregateVersion { get; }

        void BuildVersion(long aggregateVersion);
    }
}