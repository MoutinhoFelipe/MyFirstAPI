using RabbitMQ.Client;
using System;
using System.Text;

public class QueueService
{
    public QueueService()
    {

    }

    public void SendToQueue(string id_trip, string driver_name, string driver_phone)
    {
        string messageJson;
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                //messageJson = $"{{} id : {id_trip},
                
                var body = Encoding.UTF8.GetBytes(id_trip);
                channel.BasicPublish
                (
                exchange: "",
                routingKey: "queuePOST",
                basicProperties: null,
                body: body
                );
            }
        }
    }
}