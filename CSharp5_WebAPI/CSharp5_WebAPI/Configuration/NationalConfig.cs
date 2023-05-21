using CSharp5_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class NationalConfig : IEntityTypeConfiguration<National>
    {
        public void Configure(EntityTypeBuilder<National> builder)
        {
            builder.HasKey(x => x.NationalID);
            builder.Property(x => x.NationalName).HasColumnType("nvarchar(100)").IsRequired();
            
        }
    }
}
