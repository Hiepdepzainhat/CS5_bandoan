using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class ComboConfig : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.HasKey(x => x.ComboID);
            builder.Property(x => x.ComboName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.ImgCombo).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            
        }
    }
}
