using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitExamples
{
    public class SecondMessageConsumer :
        IConsumer<YourMessage>
    {
        public async Task Consume(ConsumeContext<YourMessage> context)
        {
            await Console.Out.WriteLineAsync($"SecondMessageConsumer : {context.Message.Text}");
        }
    }
}
