using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Walaks.Poc.Minimal.Api.Application.Services.Interfaces;
using Walaks.Poc.Minimal.Api.Application.ViewModels;

namespace Walaks.Poc.Minimal.Api.Endpoints
{
    public static class UseRoute
    {
        public static void UseRoutes(this WebApplication app)
        {

            var routeUser = app.MapGroup("users");

            routeUser.MapPost("",
                [Authorize(Policy = "RequireWrite")]
                [SwaggerOperation(
                    Summary = "Cria um novo usuário",
                    Description = "Adiciona um novo usuário ao sistema com base nas informações fornecidas no corpo da requisição.",
                    OperationId = "CreateUser",
                    Tags = new[] { "Usuários" }
                )]
            async (UserRequestViewModel req, IUserService service) =>
                {
                    var response = await service.AddAsync(req);
                    return Results.Created(response.Name, response);
                });

            routeUser.MapGet("",
                [Authorize(Roles = "Reader, Write")]
                [SwaggerOperation(
                    Summary = "Lista todos os usuários",
                    Description = "Requer um token de autenticação com as roles 'Reader' ou 'Write'. Retorna uma lista contendo todos os usuários cadastrados no sistema.",
                    OperationId = "GetUsuarios",
                    Tags = new[] { "Usuários" }
                )]
            async (IUserService service) => await service.GetListAsync());

            routeUser.MapGet("{id:guid}",
                [SwaggerOperation(
                    Summary = "Obtém um usuário específico",
                    Description = "Busca e retorna as informações de um usuário com base no ID fornecido.",
                    OperationId = "GetUsuarioById",
                    Tags = new[] { "Usuários" }
                )]
            async (Guid id, IUserService service) =>
                {
                    var user = await service.GetbyIdAsync(id);
                    if (user == null)
                    {
                        return Results.NotFound();
                    }
                    return Results.Ok(user);
                });

            routeUser.MapPut("{id:guid}",
                [SwaggerOperation(
                    Summary = "Atualiza um usuário",
                    Description = "Atualiza o nome de um usuário com base no ID e nas informações fornecidas.",
                    OperationId = "UpdateUser",
                    Tags = new[] { "Usuários" }
                )]
            async (UserRequestViewModel req, Guid id, IUserService service) =>
                {
                    var user = await service.GetbyIdAsync(id);
                    if (user == null)
                    {
                        return Results.NotFound();
                    }
                    user.ChangeName(req.Nome);
                    await service.UpdateAsync(user);
                    return Results.Ok(user);
                });

            routeUser.MapDelete("{id:guid}",
                [Authorize(Roles = "Delete")]
                [SwaggerOperation(
                    Summary = "Inativa um usuário",
                    Description = "Define um usuário como inativo com base no ID fornecido.",
                    OperationId = "DeleteUser",
                    Tags = new[] { "Usuários" }
                )]
            async (Guid id, IUserService service) =>
                {
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
