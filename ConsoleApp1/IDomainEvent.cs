// See https://aka.ms/new-console-template for more information
public interface IDomainEvent
{
    Guid EventId { get; }
    long AggregateVersion { get; }

    void BuildVersion(long aggregateVersion);
}
