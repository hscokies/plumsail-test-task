using System.Threading;
using Application.Forms.Get;
using Application.Forms.GetById;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Forms;

public class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(GetFormByIdQuery.Path, async (
                [AsParameters] GetFormByIdQuery query,
                [FromServices] GetFormByIdHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(query, ct);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Forms);
    }
}