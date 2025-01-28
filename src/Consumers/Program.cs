
using Consumers;
using MassTransit;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("localhost", 5672, "/", h =>
    {
        h.Username("admin"); // Substitua por seu usuário
        h.Password("123456");   // Substitua pela sua senha
    });


    cfg.ReceiveEndpoint("greet-new-customers", e =>
    {
        e.Consumer<UserCreatedConsumer>();
        e.PrefetchCount = 10;
    });

    cfg.ReceiveEndpoint("add-to-maillist", e =>
    {
        e.Consumer<AddToMailListConsumer>();
        e.PrefetchCount = 10;
    });
});
busControl.Start();

Console.WriteLine("Waiting for messages...");

while (true) ;
