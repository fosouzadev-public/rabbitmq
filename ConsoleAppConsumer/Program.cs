using Utils;

namespace ConsoleAppConsumer;

public class Program
{
    public static async Task Main(string[] args)
    {
        await using RabbitMqService rabbitMq = new();
        
        await rabbitMq.ConnectAsync();
        
        await rabbitMq.ConsumerAsync((Car car) =>
        {
            Console.WriteLine("Message consumed:");
            Console.WriteLine(car);
        });
    }
}