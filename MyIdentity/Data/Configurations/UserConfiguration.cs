using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyIdentity.Models;

namespace MyIdentity.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Role)
                 .WithMany(r => r.Users)
                 .HasForeignKey(x => x.RoleId);


        }
    }
}
