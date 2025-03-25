using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Factories;
using Domain.Entities;
using Domain.Entities.Questions;
using Domain.Errors;
using Domain.Primitives;
using Domain.Primitives.Errors;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Forms.GetById;

public sealed class GetFormByIdHandler(IDataContext dataContext) : IQueryHandler<GetFormByIdQuery, GetFormByIdResponse>
{
    public async Task<Result<GetFormByIdResponse>> Handle(GetFormByIdQuery query, CancellationToken ct)
    {
        var form = await FetchForm(query, ct);
        if (form is null)
        {
            return FormErrors.NotFound(query.Id);
        }

        return BuildResponse(form);
    }
    
    private Task<Form> FetchForm(GetFormByIdQuery query, CancellationToken ct) =>
        dataContext.Forms
            .Include(x => x.Questions)
            .ThenInclude(x => (x as OptionsQuestionBase).Options)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id, ct);

    private static GetFormByIdResponse BuildResponse(Form form)
    {
        var response = new GetFormByIdResponse(form.Id, form.Title, form.Subtitle, form.Color);
        foreach (var question in form.Questions)
        {
            response.Questions.Add(question.ToQuestionModel());
        }

        return response;
    }
}