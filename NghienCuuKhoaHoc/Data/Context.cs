using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NghienCuuKhoaHoc.Data.Configuration;
using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Data
{
    public class Context :IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<CouncilMember> CouncilMembers { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Literacy> Literacies{ get; set; }
        public DbSet<Personal> Personals{ get; set; }
        public DbSet<Position> Positions{ get; set; }
        public DbSet<Research> Researches{ get; set; }
        public DbSet<ResearchAcceptance> ResearchAcceptances{ get; set; }
        public DbSet<Field> Fields{ get; set; }
        public DbSet<ResearchFile> ResearchFiles{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entity.SetTableName(tableName.Substring(6));
                }
            }
            builder.ApplyConfiguration(new ReConfiguration());
            builder.ApplyConfiguration(new CouncilMemberConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new LiteracyConfiguration());
            builder.ApplyConfiguration(new PersonalConfiguration());
            builder.ApplyConfiguration(new PositionConfiguration());
            builder.ApplyConfiguration(new ResearchAcceptanceConfiguration());
            builder.ApplyConfiguration(new FieldConfiguration());
            builder.ApplyConfiguration(new FieldConfiguration());
            builder.Seed();
        }
        
    }
}
