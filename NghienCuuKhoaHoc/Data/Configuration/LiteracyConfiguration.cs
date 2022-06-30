using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data.Configuration
{
    public class LiteracyConfiguration : IEntityTypeConfiguration<Literacy>
    {
        public void Configure(EntityTypeBuilder<Literacy> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e=>e.Value).HasColumnType("nvarchar(128)");
            builder.HasIndex(e => e.Id);
        }
    }
}
