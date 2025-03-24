using Domain.Entities.Answers;
using Infrastructure.Persistence.DiscriminatorMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

internal class AnswerEntityConfiguration : IEntityTypeConfiguration<AnswerBase>
{
    public void Configure(EntityTypeBuilder<AnswerBase> builder)
    {
        builder.HasKey(x => x.Id);

        var discriminatorBuilder = builder.HasDiscriminator(x => x.Discriminator);
        foreach (var (discriminator, type) in AnswerDiscriminatorMapping.DiscriminatorMapping)
        {
            discriminatorBuilder.HasValue(type, discriminator);
        }
    }
}