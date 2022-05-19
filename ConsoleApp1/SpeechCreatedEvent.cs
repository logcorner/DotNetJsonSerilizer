namespace ConsoleApp
{
    public class SpeechCreatedEvent : Event
    {
        public string Title { get; }
        public string Url { get; }
        public string Description { get; }
        public SpeechTypeEnum Type { get; }

        public SpeechCreatedEvent(Guid aggregateId, string title, string url,
            string description, SpeechTypeEnum type)
        {
            AggregateId = aggregateId;
            Title = title;
            Url = url;
            Description = description;
            Type = type;
        }
    }
}