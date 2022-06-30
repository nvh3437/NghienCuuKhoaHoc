using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data.Configuration
{
    public class PersonalConfiguration : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Department).WithMany(x=>x.Personals).HasForeignKey(x=>x.DepartmentId);
            builder.Property(e=>e.Id).HasColumnType("varchar(12)");
            builder.Property(e=>e.Name).HasColumnType("nvarchar(256)");
            builder.Property(e=>e.Birth).HasColumnType("date");
            builder.Property(e=>e.DepartmentId).HasColumnType("nvarchar(128)");
            builder.Property(e=>e.Email).HasColumnType("nvarchar(128)");
            builder.Property(e=>e.PhoneNumber).HasColumnType("varchar(12)");
            builder.Property(e=>e.Literacy).HasColumnType("nvarchar(128)");
            builder.Property(e=>e.Position).HasColumnType("nvarchar(128)");
            builder.HasIndex(e => e.Id);
            builder.HasIndex(e => e.DepartmentId);
        }
    }
}
