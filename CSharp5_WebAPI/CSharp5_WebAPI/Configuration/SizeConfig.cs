using CSharp5_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class SizeConfig : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.SizeID);
            builder.Property(x => x.SizeName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.MultiplePrice).HasColumnType("int").IsRequired();
            builder.Property(x => x.Desciption).HasColumnType("nvarchar(1000)");
           
        }
    }
}
