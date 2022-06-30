using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e=>e.Value).HasColumnType("nvarchar(128)");
            builder.HasIndex(e => e.Id);
        }
    }
}
