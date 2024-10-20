﻿using Walaks.Poc.Minimal.Api.Application.ViewModels;
using Walaks.Poc.Minimal.Api.Common.Extensions;

namespace Walaks.Poc.Minimal.Api.Endpoints
{
    public static class ExtensionRoute
    {
        public static void ExtensionRoutes(this WebApplication app)
        {
            var Extension = app.MapGroup("/extension/string")
            .WithName("Extension")
            .WithOpenApi(); ;

            Extension.MapPost("", (DocumentoRequestViewModel req) =>
            {
                return Results.Ok(req.CPF.RemoverMascara());
            });
        }
    }
}
