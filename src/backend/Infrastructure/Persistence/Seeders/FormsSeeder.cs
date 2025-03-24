using System.Collections.Generic;
using Domain.Entities;
using Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeders;

internal static class FormsSeeder
{
    public static void Seed(this EntityTypeBuilder<Form> builder)
    {
        builder.HasData(new Form
        {
            Id = 1,
            Title = "RUN THE JEWELS",
            Subtitle = "Thu, Jun 5 at 07:00 PM EDT at The Amp Ballantyne",
            Color = "#7A5CFA",
        });
    }
}