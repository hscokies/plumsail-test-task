using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Application.Forms.Get;

public record GetFormsQuery([FromQuery] string Search = "") : IQuery<GetFormsResponse>
{
    public static string Path => "/api/forms";
};