using System.Threading;
using Application.Forms.Create;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Forms;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(CreateFormCommand.Path, async (
            [FromBody] CreateFormCommand request,
            [FromServices] CreateFormHandler handler,
            CancellationToken ct) =>
        {
            var result = await handler.Handle(request, ct);
            return result.Match(Results.Created, CustomResults.Problem);
        })
        .WithTags(Tags.Forms)
        .AddFluentValidationAutoValidation();
    }
}