using MassTransit;
using MassTransitWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassTransitWebApp.Consumers
{
    public class PersonConsumer :
        IConsumer<Person>
    {
        public async Task Consume(ConsumeContext<Person> context)
        {
            var person = context.Message;
            
            
            //update database, etc
        }
    }
}
