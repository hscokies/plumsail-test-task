using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Answers;
using Domain.Entities.Questions;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DataContext(DbContextOptions options) : DbContext(options), IDataContext
{
    public DbSet<Form> Forms { get; init; }
    public DbSet<QuestionBase> Questions { get; init; }
    public DbSet<QuestionOption> QuestionOptions { get; init; }
    public DbSet<Submission> Submissions { get; init; }
    public DbSet<AnswerBase> Answers { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}