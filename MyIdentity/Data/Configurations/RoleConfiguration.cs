using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyIdentity.Models;

namespace MyIdentity.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x=>x.Id);


            builder.HasMany(r => r.Permissions)
                   .WithMany(p => p.Roles)
                   .UsingEntity<RolePermission>();
            
        }
    }
}
