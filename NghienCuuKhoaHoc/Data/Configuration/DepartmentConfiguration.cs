using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e=>e.Id).HasColumnType("nvarchar(128)");
            builder.Property(e=>e.Name).HasColumnType("nvarchar(128)");
            builder.HasIndex(e => e.Id);
        }
    }
}
