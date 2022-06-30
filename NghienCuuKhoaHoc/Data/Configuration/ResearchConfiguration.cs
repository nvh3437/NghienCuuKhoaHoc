using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data.Configuration
{
    public class ReConfiguration : IEntityTypeConfiguration<Research>
    {
        public void Configure(EntityTypeBuilder<Research> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).HasColumnType("varchar(12)");
            builder.Property(e => e.Subject).HasColumnType("nvarchar(512)");
            builder.HasOne(e=>e.Personal).WithMany(e=>e.Researches).HasForeignKey(e=>e.InstructorId).OnDelete(DeleteBehavior.SetNull);
            builder.Property(e => e.Field).HasColumnType("nvarchar(128)");
            builder.Property(e => e.Expense).HasDefaultValue(0);
            builder.Property(e => e.Expense).HasColumnType("decimal(10,2)");
            builder.Property(e => e.Status).HasDefaultValue(General.Enum.ResearchStatus.Handed);
            builder.HasIndex(e => e.InstructorId);
            builder.HasIndex(e => e.Field);
            builder.HasIndex(e => e.Expense);
            builder.HasIndex(e => e.DateExpired);
            builder.HasIndex(e => e.DateStarted);
            builder.HasIndex(e => e.Status);
        }
    }
}
