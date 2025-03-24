using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace InventoryService.Services
{
    public class RabbitMQSubscriber
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQSubscriber()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection(); // ✅ Works in v6.4.0
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "order-placed",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[InventoryService] Stock updated for: {message}");
            };

            _channel.BasicConsume(queue: "order-placed",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("[InventoryService] 🐇 Waiting for messages...");
        }
    }
}
