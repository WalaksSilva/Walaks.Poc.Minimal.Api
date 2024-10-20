using Microsoft.EntityFrameworkCore;
using Walaks.Poc.Minimal.Api.Context;
using Walaks.Poc.Minimal.Api.Models;
using Walaks.Poc.Minimal.Api.ViewModels;

namespace Walaks.Poc.Minimal.Api.Endpoints
{
    public static class UseRoute
    {
        public static void UseRoutes(this WebApplication app)
        {
            var routeUser = app.MapGroup("users");

            routeUser.MapPost("", async (UserRequestViewModel req, EntityContext context) => {
                var userModel = new UserModel(req.Nome);

                await context.Users.AddAsync(userModel);
                await context.SaveChangesAsync();

                return Results.Created(userModel.Name, userModel);
            });

            routeUser.MapGet("", async (EntityContext context) => await context.Users.ToListAsync());

            routeUser.MapGet("{id:guid}", async (Guid id, EntityContext context) => {
                return Results.Ok(await context.Users.FirstOrDefaultAsync(x => x.Id == id));
            });

        }
    }
}
