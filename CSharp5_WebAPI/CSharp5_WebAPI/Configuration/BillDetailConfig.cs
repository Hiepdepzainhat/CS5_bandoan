using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class BillDetailConfig : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.BillDetailID);
            builder.Property(x => x.Price).HasColumnType("int").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Bill).WithMany(x => x.BillDetail).HasForeignKey(x => x.BillID); 
            builder.HasOne(x => x.Products).WithMany(x => x.BillDetails).HasForeignKey(x => x.ProductID);
            
        }
    }
}
