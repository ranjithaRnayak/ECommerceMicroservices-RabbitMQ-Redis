namespace Shared
{
     public static class EventBus
    {
        public static event Action<string, object>? OnEvent;

        public static void Publish(string eventName, object data)
        {
            Console.WriteLine($"[EventBus] Event Published: {eventName}");
            OnEvent?.Invoke(eventName, data);
        }

        public static void Subscribe(string eventName, Action<object> handler)
        {
            OnEvent += (e, data) =>
            {
                if (e == eventName)
                    handler(data);
            };
        }
    }   
}       