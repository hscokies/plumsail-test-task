using Domain.Entities.Questions;
using Infrastructure.Persistence.DiscriminatorMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

internal class QuestionEntityConfiguration : IEntityTypeConfiguration<QuestionBase>
{
    public void Configure(EntityTypeBuilder<QuestionBase> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Key)
            .HasMaxLength(256)
            .IsRequired();
        builder.Property(x => x.Title)
            .HasMaxLength(256)
            .IsRequired();
        builder.Property(x => x.Placeholder)
            .HasMaxLength(64);
        builder.Property(x => x.Validator)
            .HasMaxLength(256);

        var discriminatorBuilder = builder.HasDiscriminator(x => x.Discriminator);
        foreach (var (discriminator, type) in QuestionDiscriminatorMapping.DiscriminatorMapping)
        {
            discriminatorBuilder.HasValue(type, discriminator);
        }
    }
}