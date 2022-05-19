using System.Text.Json;

namespace ConsoleApp
{
    public class JsonDotNetProvider : IJsonProvider
    {
        public TEvent DeserializeObject<TEvent>(string serializedEvent, string eventType)
        {
            JsonSerializerOptions settings = new JsonSerializerOptions
            {
                IncludeFields = true
            };
            return (TEvent)JsonSerializer.Deserialize(serializedEvent, Type.GetType(eventType), settings);
        }

        public string SerializeObject<TEvent>(TEvent domainEvent)
        {
            string serializedEvent = JsonSerializer.Serialize(domainEvent, domainEvent.GetType());

            return serializedEvent;
        }
    }
}