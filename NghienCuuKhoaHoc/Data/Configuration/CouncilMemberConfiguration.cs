using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data.Configuration
{
    public class CouncilMemberConfiguration : IEntityTypeConfiguration<CouncilMember>
    {
        public void Configure(EntityTypeBuilder<CouncilMember> builder)
        {
            builder.HasKey(x => new { x.ResearchId, x.MemberId });
            builder.HasOne(e=>e.Research).WithMany(e=>e.CouncilMembers).HasForeignKey(e=>e.ResearchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e=>e.Personal).WithMany(e=>e.CouncilMembers).HasForeignKey(e=>e.MemberId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(e => e.Position);
        }
    }
}
