using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class CategoryConfig : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(x => x.CategoryID);
            builder.Property(x => x.CategoryName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
        }
    }
}
