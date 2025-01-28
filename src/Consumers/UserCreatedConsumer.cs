using MassTransit;
using Walaks.Poc.Minimal.Api.Domain.Events;


namespace Consumers
{
    public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            Console.WriteLine($"Novo cliente cadastrado: [{context.Message.Id}] - {context.Message.Name}");
            return Task.CompletedTask;
        }
    }
}
