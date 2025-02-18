﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabitMqPrdouctApi.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
            // Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("product", exclusive: false);
                //Serialize the message
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "", routingKey: "product", body: body);
            }
        }

          
    }
}
