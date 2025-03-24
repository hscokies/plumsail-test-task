using System.Threading;
using System.Threading.Tasks;
using Domain.Primitives;

namespace Application.Abstractions;

public interface IQueryHandler;
public interface IQueryHandler<in TQuery, TResponse> : IQueryHandler
    where TQuery : IQuery<TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken ct);
}