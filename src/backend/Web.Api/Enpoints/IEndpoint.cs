using Microsoft.AspNetCore.Routing;

namespace Web.Api.Enpoints;

internal interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}