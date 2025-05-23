using Microsoft.AspNetCore.Routing;

namespace Web.Api.Endpoints;

internal interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}