// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");
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

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Message received: {message}");
};

channel.BasicConsume(queue: "students", autoAck: true, consumer: consumer);

Console.ReadKey();
