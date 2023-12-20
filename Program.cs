

using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "inbox" ,
    durable:false , exclusive:false ,autoDelete: false , arguments:null);

var message = " ";

while (message != String.Empty)
{
    Console.Write("Please Enter Message Then Press Enter:");
    message = Console.ReadLine();
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "", routingKey: "inbox", basicProperties: null, body);

    Console.WriteLine("Message Sent to Client1");
}
