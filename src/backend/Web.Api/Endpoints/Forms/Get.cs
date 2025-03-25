using System.Threading;
using Application.Forms.Get;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Forms;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(GetFormsQuery.Path, async (
                [AsParameters] GetFormsQuery query,
                [FromServices] GetFormsHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(query, ct);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Forms);
    }
}