using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

internal class FormEntityConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Title);

        builder.Property(x => x.Title)
            .HasMaxLength(128)
            .IsRequired();
        builder.Property(x => x.Subtitle)
            .HasMaxLength(512);
        builder.Property(x => x.Color)
            .HasMaxLength(7);

        builder.HasMany(x => x.Questions)
            .WithOne(x => x.Form)
            .HasForeignKey(x => x.FormId);
    }
}