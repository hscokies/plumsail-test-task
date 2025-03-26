using System.Threading;
using Application.Submissions.Get;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Submissions;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(GetSubmissionsQuery.Path, async (
                [AsParameters] GetSubmissionsQuery query,
                [FromServices] GetSubmissionsHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(query, ct);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Submissions);
    }
}