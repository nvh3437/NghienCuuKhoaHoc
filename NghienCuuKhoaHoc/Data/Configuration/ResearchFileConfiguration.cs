using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data.Configuration
{
    public class ResearchFileConfiguration : IEntityTypeConfiguration<ResearchFile>
    {
        public void Configure(EntityTypeBuilder<ResearchFile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e=>e.Id).HasColumnType("varchar(256)");
            builder.Property(e=>e.Name).HasColumnType("nvarchar(256)");
            builder.Property(e=>e.File).HasColumnType("nvarchar(256)");
            builder.Property(e=>e.FileExtend).HasColumnType("nvarchar(64)");
            builder.HasOne(e=>e.Research).WithMany(e=>e.ResearchFiles).HasForeignKey(e=>e.ResearchId);
        }
    }
}
