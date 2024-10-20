namespace Walaks.Poc.Minimal.Api.Domain.Entities
{
    public class UserEntity
    {
        public UserEntity(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; init; }
        public string Name { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void SetInactive()
        {
            Name = "desativado";
        }
    }
}
