namespace ConsoleApp
{
    internal class Program
    {
        private static IJsonProvider _jsonDotNetProvider = new JsonDotNetProvider();
        private static IJsonProvider _jsonNewtonsoftProvider = new JsonNewtonsoftProvider();

        private static void Main(string[] args)
        {
            var domainEvent = new SpeechCreatedEvent(Guid.NewGuid(),
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                "http://evt.com",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries",
                new SpeechTypeEnum(1, "Created")
                );

            //   Serialize using Newtonsoft.Json ==>  good
            var jsonNewtonsoftSerializedString = _jsonNewtonsoftProvider.SerializeObject<IDomainEvent>(domainEvent);

            //   Serialize using System.Text.Json ==>  good
            var jsonDotNetSerializedString = _jsonDotNetProvider.SerializeObject<IDomainEvent>(domainEvent);

            string? assemblyQualifiedName = domainEvent.GetType().AssemblyQualifiedName;
            //   Deserialize using Newtonsoft.Json ==>  good
            var speechCreatedEventDeserializeWithNewtonsoft = _jsonNewtonsoftProvider.DeserializeObject<SpeechCreatedEvent>(jsonNewtonsoftSerializedString, assemblyQualifiedName);

            //   Deserialize using System.Text.Json ==>  throw exception
            var speechCreatedEventDeserializeWithJsonDotNet = _jsonDotNetProvider.DeserializeObject<SpeechCreatedEvent>(jsonDotNetSerializedString, assemblyQualifiedName);
        }
    }
}