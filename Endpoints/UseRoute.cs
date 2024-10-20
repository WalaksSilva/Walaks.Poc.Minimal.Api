using Walaks.Poc.Minimal.Api.Application.Services.Interfaces;
using Walaks.Poc.Minimal.Api.Application.ViewModels;

namespace Walaks.Poc.Minimal.Api.Endpoints
{
    public static class UseRoute
    {
        public static void UseRoutes(this WebApplication app)
        {
            var routeUser = app.MapGroup("users");

            routeUser.MapPost("", async (UserRequestViewModel req, IUserService service) => {

                var response = await service.AddAsync(req);

                return Results.Created(response.Name, response);
            });

            routeUser.MapGet("", async (IUserService service) => await service.GetListAsync());

            routeUser.MapGet("{id:guid}", async (Guid id, IUserService service) => {

                var user = await service.GetbyIdAsync(id);

                if (user == null)
                { 
                    return Results.NotFound();
                }

                return Results.Ok(user);
            });

            routeUser.MapPut("{id:guid}", async(UserRequestViewModel req, Guid id, IUserService service) => {

                var user = await service.GetbyIdAsync(id);

                if (user == null) 
                {
                    return Results.NotFound();
                }

                user.ChangeName(req.Nome);
                await service.UpdateAsync(user);

                return Results.Ok(user);
            });

            routeUser.MapDelete("{id:guid}", async (Guid id, IUserService service) => {

                var user = await service.GetbyIdAsync(id);

                if (user == null)
                {
                    return Results.NotFound();
                }

                user.SetInactive();
                await service.UpdateAsync(user);

                return Results.Ok();
            });

        }
    }
}
