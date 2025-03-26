using Application.Abstractions;

namespace Application.Submissions.Get;

public record GetSubmissionsQuery(string Search = "") : IQuery<GetSubmissionsResponse>
{
    public static string Path => "/api/submissions";
}