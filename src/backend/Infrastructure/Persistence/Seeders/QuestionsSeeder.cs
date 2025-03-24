using Domain.Entities;
using Domain.Entities.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeders;

internal static class QuestionsSeeder
{
    public static void Seed(this EntityTypeBuilder<OpenQuestion> builder)
    {
        builder.HasData(new OpenQuestion()
        {
            Id = 1,
            FormId = 1,
            Key = "email",
            Title = "Email",
            Placeholder = "Enter email address",
            Validator = "email"
        });
    }


    public static void Seed(this EntityTypeBuilder<DateQuestion> builder)
    {
        builder.HasData(new DateQuestion()
        {
            Id = 2,
            FormId = 1,
            Key = "birthdate",
            Title = "Date of birth",
            Validator = "birthdate"
        });
    }
    
    public static void Seed(this EntityTypeBuilder<SelectionQuestion> builder)
    {
        builder.HasData(new SelectionQuestion()
        {
            Id = 3,
            FormId = 1,
            Key = "ticket-type",
            Title = "Ticket Type",
        });
    }
    
    public static void Seed(this EntityTypeBuilder<SingleOptionQuestion> builder)
    {
        builder.HasData(new SingleOptionQuestion()
        {
            Id = 4,
            FormId = 1,
            Key = "preferred-seating",
            Title = "Preferred Seating",
        });
    }
    
    public static void Seed(this EntityTypeBuilder<MultipleOptionsQuestion> builder)
    {
        builder.HasData(new MultipleOptionsQuestion()
        {
            Id = 5,
            FormId = 1,
            Key = "add-ons",
            Title = "Add-ons",
            Validator = "none",
        });
    }
}