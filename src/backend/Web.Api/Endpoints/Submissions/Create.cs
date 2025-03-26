using System.Threading;
using Application.Submissions.Create;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Submissions;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(CreateSubmissionCommand.Path, async (
                [FromBody] CreateSubmissionCommand query,
                [FromServices] CreateSubmissionHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(query, ct);
                return result.Match(
                    () => Results.Created(CreateSubmissionCommand.Path, result.Value),
                    CustomResults.Problem);
            })
            .WithTags(Tags.Submissions);
    }
}