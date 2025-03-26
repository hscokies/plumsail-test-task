using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Forms.Get;

public sealed class GetFormsHandler(IDataContext dataContext, IMemoryCache memoryCache)
    : IQueryHandler<GetFormsQuery, GetFormsResponse>
{
    private readonly MemoryCacheEntryOptions _cacheOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
        Size = 1
    };

    public async Task<Result<GetFormsResponse>> Handle(GetFormsQuery query, CancellationToken ct)
    {
        if (memoryCache.TryGetValue<GetFormsResponse>(query.Search, out var response))
        {
            return response;
        }

        response = await FetchForms(query, ct);
        memoryCache.Set(query.Search, response, _cacheOptions);
        return response;
    }

    private async Task<GetFormsResponse> FetchForms(GetFormsQuery query, CancellationToken ct)
    {
        var forms = new GetFormsResponse();
        var formsQuery = GetFormsQuery(query);
        await foreach (var formData in formsQuery.AsAsyncEnumerable().WithCancellation(ct))
        {
            var form = new GetFormModel(
                formData.Id, formData.Title,
                formData.Subtitle, formData.Color);

            forms.Add(form);
        }

        return forms;
    }
    
    private IQueryable<Form> GetFormsQuery(GetFormsQuery query)
    {
        if (dataContext.Database.IsNpgsql())
        {
            // That's not very good practice cause of index utilization, but who cares : D
            return dataContext.Forms.Where(q => EF.Functions.ILike(q.Title, $"%{query.Search}%") ||
                                                EF.Functions.ILike(q.Subtitle, $"%{query.Search}%"));
        }

        return dataContext.Forms.Where(q => q.Title.Contains(query.Search, StringComparison.OrdinalIgnoreCase) ||
                                            q.Subtitle.Contains(query.Search, StringComparison.OrdinalIgnoreCase));
            
    }
}