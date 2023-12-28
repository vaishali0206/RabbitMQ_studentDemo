using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Student_Records.Services
{
    public class RabbitMQProducer:IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost", // RabbitMQ server hostname or IP address
                Port = 5672,             // Default RabbitMQ port
                UserName = "guest",      // Default RabbitMQ username
                Password = "guest"// Default RabbitMQ password
                                  // Add other configuration settings as needed
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("students", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "students", body: body);
        }
    }
}
