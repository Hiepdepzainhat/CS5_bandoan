using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.UserName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.PassWord).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(13)").IsRequired();
            builder.Property(x => x.Address).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnType("Date").IsRequired();
            builder.Property(x => x.Sex).HasColumnType("int").IsRequired();
            builder.Property(x => x.ImgUser).HasColumnType("nvarchar(1000)");
/*            builder.HasOne(p => p.Role).WithMany(p => p.Users).HasForeignKey(p => p.RoleID);
            builder.HasOne(p => p.National).WithMany(p => p.Users).HasForeignKey(p => p.NationalID);*/
        }
    }
}
