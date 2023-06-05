using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class ComboItemConfig : IEntityTypeConfiguration<ComboItems>
    {
        public void Configure(EntityTypeBuilder<ComboItems> builder)
        {
            builder.HasKey(x => x.ComboItemID);
            builder.Property(x => x.Price).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Products).WithMany(x => x.ComboItems).HasForeignKey(x => x.ProductID);
            builder.HasOne(x => x.Combo).WithMany(x => x.ComboItems).HasForeignKey(x => x.ComboItemID);
        }
    }
}
