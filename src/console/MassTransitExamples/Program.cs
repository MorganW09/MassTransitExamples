using MassTransit;
using System;

namespace MassTransitExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Example3();
        }

        public static void BasicExample()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "test_queue", ep =>
                {
                    ep.Handler<YourMessage>(context =>
                    {
                        return Console.Out.WriteLineAsync($"Received: {context.Message.Text}");
                    });
                });
            });

            bus.Start();

            bus.Publish(new YourMessage { Text = "Hi" });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();

        }

        public static void Example2()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "test_queue", ep =>
                {
                    ep.Consumer<YourMessageConsumer>();
                });
            });

            bus.Start();

            bus.Publish(new YourMessage { Text = "Hi" });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();

        }

        public static void Example3()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "test_queue", ep =>
                {
                    ep.Consumer<YourMessageConsumer>();
                    ep.Consumer<SecondMessageConsumer>();
                });
            });

            bus.Start();

            bus.Publish(new YourMessage { Text = "Hi" });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();

        }
    }

    public class YourMessage
    {
        public string Text { get; set; }
    }
}
