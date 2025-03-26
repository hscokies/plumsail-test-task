using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeders;

internal static class FormsSeeder
{
    public static void Seed(this EntityTypeBuilder<Form> builder)
    {
        // Add forms here if needed
        builder.HasData();
    }
}