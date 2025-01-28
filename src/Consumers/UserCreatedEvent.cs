namespace Walaks.Poc.Minimal.Api.Domain.Events
{
    public interface UserCreatedEvent
    {
        string Id { get; set; }
        string? Name { get; set; }
    }
}
