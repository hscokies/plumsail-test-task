using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

internal class SubmissionEntityConfiguration : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Form)
            .WithMany(x => x.Submissions)
            .HasForeignKey(x => x.FormId);

        builder.HasMany(x => x.Answers)
            .WithOne(x => x.Submission)
            .HasForeignKey(x => x.SubmissionId);
    }
}