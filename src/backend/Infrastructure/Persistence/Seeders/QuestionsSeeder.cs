using Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeders;

internal static class QuestionsSeeder
{
    public static void Seed(this EntityTypeBuilder<OpenQuestion> builder)
    {
        // Add open questions here if needed
        builder.HasData();
    }


    public static void Seed(this EntityTypeBuilder<DateQuestion> builder)
    {
        // Add date questions here if needed
        builder.HasData();
    }
    
    public static void Seed(this EntityTypeBuilder<SelectionQuestion> builder)
    {
        // Add selection (dropdown) questions here if needed
        builder.HasData();
    }
    
    public static void Seed(this EntityTypeBuilder<SingleOptionQuestion> builder)
    {
        // Add single option (radio) questions here if needed
        builder.HasData();
    }
    
    public static void Seed(this EntityTypeBuilder<MultipleOptionsQuestion> builder)
    {
        // Add multi option (checkbox) questions here if needed
        builder.HasData();
    }
}