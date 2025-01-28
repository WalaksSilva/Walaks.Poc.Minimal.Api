using MassTransit;
using Walaks.Poc.Minimal.Api.Domain.Events;

namespace Consumers
{
    public class AddToMailListConsumer : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var id = context.Message.Id;
            var name = context.Message.Name;

            Console.WriteLine($"Novo cliente cadastrado: [{id}] - {name}");
            return Task.CompletedTask;
        }
    }
}
