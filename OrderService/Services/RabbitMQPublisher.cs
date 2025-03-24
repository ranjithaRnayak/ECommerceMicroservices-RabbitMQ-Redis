using RabbitMQ.Client;
using System.Text;

namespace OrderService.Services
{
    public class RabbitMQPublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection();  // ✅ This works with v6.4.0
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "order-placed",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                 routingKey: "order-placed",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($"[OrderService] 📦 Published: {message}");
        }
    }
}
