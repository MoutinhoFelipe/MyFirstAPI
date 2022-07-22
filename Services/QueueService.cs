using Microsoft.AspNetCore.Mvc;
using MyFirstAPI;
using MyFirstAPI.Requests;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

public class QueueService
{
    public QueueService()
    {

    }

    public void SendToQueue(Trip trip)
    {
        var factory = new ConnectionFactory()
        {
            HostName = MyConfig.HostName
        };
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                string message = JsonSerializer.Serialize(trip);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish
                (
                exchange: "",
                routingKey: MyConfig.QueueName,
                basicProperties: null,
                body: body
                );
            }
        }
    }
}