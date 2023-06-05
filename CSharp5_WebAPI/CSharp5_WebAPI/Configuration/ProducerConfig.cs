using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class ProducerConfig : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasKey(x => x.ProducerID);
            builder.Property(x => x.ProducerName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(1000)").IsRequired();

        }
    }
}
