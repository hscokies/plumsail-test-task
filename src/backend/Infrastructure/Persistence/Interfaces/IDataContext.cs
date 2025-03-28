using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Answers;
using Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Persistence.Interfaces;

public interface IDataContext
{
    DatabaseFacade Database { get; }
    DbSet<Form> Forms { get; init; }
    DbSet<QuestionBase> Questions { get; init; }
    DbSet<QuestionOption> QuestionOptions { get; init; }
    DbSet<Submission> Submissions { get; init; }
    DbSet<AnswerBase> Answers { get; init; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}