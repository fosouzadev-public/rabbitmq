using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Utils;

public class RabbitMqService : IAsyncDisposable
{
    private IConnection _connection;
    private IChannel _channel;
    
    public async Task ConnectAsync()
    {
        ConnectionFactory factory = new()
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "admin",
            Password = "Abc-123456",
            VirtualHost = "/",
            //Uri = new Uri("amqp://localhost:5672")
        };

        _connection = await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();
    }

    public async Task PublishAsync(Car car)
    {
        byte[] body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(car));
        await _channel.BasicPublishAsync("exchange-test", null, true, new BasicProperties(), body);
    }

    public async Task ConsumerAsync<T>(Action<T> action)
    {
        AsyncEventingBasicConsumer consumer = new(_channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);
            T obj = JsonConvert.DeserializeObject<T>(message);

            action(obj);
            
            return Task.CompletedTask;
        };

        await _channel.BasicConsumeAsync("queue-test", true, consumer);
    }
    
    public async ValueTask DisposeAsync()
    {
        await _channel.DisposeAsync();
        await _connection.DisposeAsync();
    }
}