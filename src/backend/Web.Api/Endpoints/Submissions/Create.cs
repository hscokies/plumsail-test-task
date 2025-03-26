using System.Threading;
using Application.Submissions.SubmitForm;
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
        app.MapPost(SubmitFormCommand.Path, async (
                [FromBody] SubmitFormCommand query,
                [FromServices] SubmitFormHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(query, ct);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Submissions);
    }
}