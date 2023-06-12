using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class BillConfig : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(x => x.BillID);
            builder.Property(x => x.CreateDate).HasColumnType("Date").IsRequired();
            builder.Property(x => x.Price).HasColumnType("int").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Bills).HasForeignKey(x => x.UserID);

        }
    }
}
