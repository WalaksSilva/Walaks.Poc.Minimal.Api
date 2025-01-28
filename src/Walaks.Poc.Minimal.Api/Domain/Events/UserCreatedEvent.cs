namespace Walaks.Poc.Minimal.Api.Domain.Events
{
    public interface UserCreatedEvent
    {
        Guid Id { get; }
        string? Name { get; }
    }
}
