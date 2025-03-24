using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeders;

internal static class QuestionOptionsSeeder
{
    public static void Seed(this EntityTypeBuilder<QuestionOption> builder)
    {
        builder.HasData(
            new QuestionOption()
            {
                Id = 1,
                QuestionId = 3,
                Value = "General Admission"
            },
            new QuestionOption()
            {
                Id = 2,
                QuestionId = 3,
                Value = "VIP"
            },
            new QuestionOption()
            {
                Id = 3,
                QuestionId = 3,
                Value = "Student"
            },
            new QuestionOption()
            {
                Id = 4,
                QuestionId = 4,
                Value = "Front row"
            },
            new QuestionOption()
            {
                Id = 5,
                QuestionId = 4,
                Value = "Middle row"
            },
            new QuestionOption()
            {
                Id = 6,
                QuestionId = 4,
                Value = "Back row"
            },
            new QuestionOption()
            {
                Id = 7,
                QuestionId = 5,
                Value = "Parking Pass"
            },
            new QuestionOption()
            {
                Id = 8,
                QuestionId = 5,
                Value = "Afterpaty ticket"
            },
            new QuestionOption()
            {
                Id = 9,
                QuestionId = 5,
                Value = "Backstage pass"
            });
    }
}