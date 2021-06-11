using System;
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using RabbitMQProvider.Config;
using DataProvider.Entities;
using System.Net.Http;

namespace RabbitMQProvider.Send
{
    public class Sender: ISender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        private IConnection _connection;
        private IModel _channel;

        public Sender(IRabbitMQConfiguration rabbitMqOptions, string queueName)
        {
            _queueName = queueName;
            _hostname = rabbitMqOptions.Hostname;
            _username = rabbitMqOptions.UserName;
            _password = rabbitMqOptions.Password;

            CreateChannel();
        }

        public void Send(object obj)
        {
            if (!ChannelExists())
            {
                CreateChannel();
            }

            var json = JsonConvert.SerializeObject(obj);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private void CreateChannel()
        {
            if (!ConnectionExists())
            {
                CreateConnection();
            }

            try
            {
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create channel: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            return _connection != null;
        }

        private bool ChannelExists()
        {
            return _channel != null;
        }
    }
}
