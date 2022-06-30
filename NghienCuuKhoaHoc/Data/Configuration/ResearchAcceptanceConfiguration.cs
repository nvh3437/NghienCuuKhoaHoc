using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data.Configuration
{
    public class ResearchAcceptanceConfiguration : IEntityTypeConfiguration<ResearchAcceptance>
    {
        public void Configure(EntityTypeBuilder<ResearchAcceptance> builder)
        {
            builder.HasKey(x => x.ResearchId);
            builder.HasOne(x => x.Research).WithOne(e=>e.ResearchAcceptance).HasForeignKey<ResearchAcceptance>(x => x.ResearchId);
            builder.HasIndex(e => e.ResearchId).IsUnique();
            builder.HasIndex(e => e.Rating);
            builder.HasIndex(e => e.Score);
            builder.HasIndex(e => e.Acceptance);
        }
    }
}
