using CSharp5_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.RoleID);
            builder.Property(x => x.RoleName).HasColumnType("nvarchar(1000)").IsRequired();
            
        }
    }
}
