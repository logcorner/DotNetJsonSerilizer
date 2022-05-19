using System.Text.Json;

namespace ConsoleApp
{
    public class JsonDotNetProvider : IJsonProvider
    {
        public TEvent DeserializeObject<TEvent>(string serializedEvent, string eventType)
        {
            if (string.IsNullOrWhiteSpace(serializedEvent))
            {
                throw new ArgumentNullException(nameof(serializedEvent));
            }
            if (string.IsNullOrWhiteSpace(eventType))
            {
                throw new ArgumentNullException(nameof(eventType));
            }
            JsonSerializerOptions settings = new JsonSerializerOptions
            {
                IncludeFields = true
            };
           var result = JsonSerializer.Deserialize(serializedEvent, Type.GetType(eventType) ?? throw new InvalidOperationException(), settings);
           if (result == null)
           {
               throw new Exception($"cannot deserialize serializedEvent {serializedEvent}");
           }
           return (TEvent) result;
        }

        public string SerializeObject<TEvent>(TEvent domainEvent)
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }
            string serializedEvent = JsonSerializer.Serialize(domainEvent, domainEvent.GetType());

            return serializedEvent;
        }
    }
}