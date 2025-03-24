using System;
using System.Collections.Generic;
using System.Threading;
using Application.Forms.Get;
using Domain.Primitives;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Web.Api.Infrastructure;

namespace Web.Api.Enpoints.Forms;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(GetFormsQuery.Path, async (
                string title,
                [FromServices] GetFormsHandler handler,
                CancellationToken ct) =>
            {
                var query = new GetFormsQuery(title);
                var result = await handler.Handle(query, ct);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Forms);
    }
}