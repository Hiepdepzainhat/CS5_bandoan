using CSharp5_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class ChefConfig : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.HasKey(x => x.ChefID);
            builder.Property(x => x.ChefName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.ChefDescription).HasColumnType("nvarchar(1000)");
        }
    }
}
