using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Mappers;
using Application.Models;
using Domain.Entities;
using Domain.Entities.Questions;
using Domain.Primitives;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Forms.Get;

public sealed class GetFormsHandler(IDataContext dataContext) : IQueryHandler<GetFormsQuery, GetFormsResponse>
{
    public async Task<Result<GetFormsResponse>> Handle(GetFormsQuery query, CancellationToken ct)
        => await FetchForms(query, ct);

    private async Task<GetFormsResponse> FetchForms(GetFormsQuery query, CancellationToken ct)
    {
        var forms = new GetFormsResponse();
        var formsQuery = GetFormsQuery(query);
        await foreach (var formData in formsQuery.AsAsyncEnumerable().WithCancellation(ct))
        {
            var form = new GetFormModel(formData.Id);
            foreach (var question in formData.Questions)
            {
                form.Questions.Add(question.ToQuestionModel());
            }

            forms.Add(form);
        }

        return forms;
    }
    
    private IQueryable<Form> GetFormsQuery(GetFormsQuery query)
    {
        var formsQuery = dataContext.Forms.AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Title))
        {
            formsQuery = formsQuery.Where(q => EF.Functions.ILike(q.Title, $"%{query.Title}%"));
        }

        return formsQuery.Include(x => x.Questions)
            .ThenInclude(x => (x as OptionsQuestionBase).Options);
    }
}