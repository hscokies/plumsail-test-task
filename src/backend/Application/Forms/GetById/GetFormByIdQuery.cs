using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Application.Forms.GetById;

public record GetFormByIdQuery(int Id) : IQuery<GetFormByIdResponse>
{
    public static string Path => "/api/forms/{Id:int}";
}