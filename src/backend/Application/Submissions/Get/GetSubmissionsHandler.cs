using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Submissions.Get.AnswerModels;
using Domain.Entities;
using Domain.Entities.Answers;
using Domain.Entities.Questions;
using Domain.Primitives;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Submissions.Get;

public sealed class GetSubmissionsHandler(IDataContext dataContext, IMemoryCache memoryCache)
    : IQueryHandler<GetSubmissionsQuery, GetSubmissionsResponse>
{
    private readonly MemoryCacheEntryOptions _cacheOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
        Size = 1
    };

    public async Task<Result<GetSubmissionsResponse>> Handle(GetSubmissionsQuery query, CancellationToken ct)
    {
        if (memoryCache.TryGetValue<GetSubmissionsResponse>(query.Search, out var response))
        {
            return response;
        }

        response = await BuildResponse(query, ct);
        memoryCache.Set(query.Search, response, _cacheOptions);

        return response;
    }

    private async Task<GetSubmissionsResponse> BuildResponse(GetSubmissionsQuery query, CancellationToken ct)
    {
        var response = new GetSubmissionsResponse();
        await foreach (var submission in GetSubmissionsQuery(query).WithCancellation(ct))
        {
            var model = new GetSubmissionModel(
                submission.Id, submission.FormId,
                submission.Form.Title, submission.Form.Subtitle,
                submission.Form.Color);

            foreach (var answer in GetAnswerModels(submission.Answers))
            {
                model.Answers.Add(answer);
            }

            response.Add(model);
        }

        return response;
    }

    private static IEnumerable<AnswerModel> GetAnswerModels(ICollection<AnswerBase> answers)
    {
        foreach (var answer in answers.Where(x => x.Question is not MultipleOptionsQuestion))
        {
            AnswerModel model = answer switch
            {
                OpenAnswer openAnswer => OpenAnswerModel.Create(openAnswer),
                DateAnswer dateAnswer => DateAnswerModel.Create(dateAnswer),
                OptionAnswer optionAnswer => SingleOptionAnswerModel.Create(optionAnswer),
                _ => throw new ArgumentOutOfRangeException(nameof(answer))
            };
            yield return model;
        }

        var multiAnswerModels =
            answers.Where(x => x.Question is MultipleOptionsQuestion)
                .OfType<OptionAnswer>()
                .GroupBy(x => x.Question.Id)
                .Select(x => MultipleOptionsAnswerModel.Create(x.ToArray()));

        foreach (var model in multiAnswerModels)
        {
            yield return model;
        }
    }

    private IAsyncEnumerable<Submission> GetSubmissionsQuery(GetSubmissionsQuery query)
    {
        var submissionsQuery = dataContext.Submissions.AsQueryable();
        if (dataContext.Database.IsNpgsql())
        {
            submissionsQuery = submissionsQuery
                .Where(x => EF.Functions.ILike(x.Form.Title, $"%{query.Search}%") ||
                            EF.Functions.ILike(x.Form.Subtitle, $"%{query.Search}%"));
        }
        else
        {
            submissionsQuery = submissionsQuery.Where(x =>
                x.Form.Title.Contains(query.Search, StringComparison.OrdinalIgnoreCase) ||
                x.Form.Subtitle.Contains(query.Search, StringComparison.OrdinalIgnoreCase));
        }

        return submissionsQuery
            .Include(x => x.Form)
            .Include(x => x.Answers)
            .ThenInclude(x => x.Question)
            .ThenInclude(x => (x as OptionsQuestionBase).Options)
            .AsAsyncEnumerable();
    }
}