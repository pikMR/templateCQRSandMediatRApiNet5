namespace Applicant.Persistance.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Applicant.Domain.Entities;
    class TestApplicantConfiguration : IEntityTypeConfiguration<TestApplicant>
    {
        public void Configure(EntityTypeBuilder<TestApplicant> builder)
        {
            builder.Property(ta => ta.FirstName)
                .IsRequired();

            builder.Property(ta => ta.LastName)
                .IsRequired();

            builder.Property(ta => ta.DateOfBirth)
                .IsRequired();

            builder.HasKey(ta => ta.ID);
        }
    }
}
