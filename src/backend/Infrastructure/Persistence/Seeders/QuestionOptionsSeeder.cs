using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeders;

internal static class QuestionOptionsSeeder
{
    public static void Seed(this EntityTypeBuilder<QuestionOption> builder)
    {
        // Add answer options here if needed
        builder.HasData();
    }
}