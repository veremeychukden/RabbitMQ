﻿using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Test",
                    durable: false,
                    autoDelete: false,
                    arguments: null);

                string message = "Hello world";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
                Console.WriteLine(message); 
            }
    }
}