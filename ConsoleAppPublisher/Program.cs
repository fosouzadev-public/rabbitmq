using AutoFixture;
using Utils;

namespace ConsoleAppPublisher;

public class Program
{
    public static async Task Main(string[] args)
    {
        await using RabbitMqService rabbitMq = new();
        
        await rabbitMq.ConnectAsync();
        
        await rabbitMq.PublishAsync(new Fixture().Create<Car>());
        Console.WriteLine("Message published.");
    }
}