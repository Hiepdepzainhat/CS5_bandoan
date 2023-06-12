using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.EntryPrice).HasColumnType("int").IsRequired();
            builder.Property(x => x.DateOfManufacture).HasColumnType("Date").IsRequired();
            builder.Property(x => x.Expired).HasColumnType("Date").IsRequired();
            builder.Property(x => x.ImPortDate).HasColumnType("Date").IsRequired();
            builder.Property(x => x.Price).HasColumnType("int").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.Property(x => x.Desciption).HasColumnType("nvarchar(1000)");
            builder.HasOne(x => x.Categories).WithMany(x => x.Productss).HasForeignKey(x => x.CategoryID);
            builder.HasOne(x => x.Producer).WithMany(x => x.Productss).HasForeignKey(x => x.ProducerID);
            builder.HasOne(x => x.Chef).WithMany(x => x.Products).HasForeignKey(x => x.ChefID);
            builder.HasOne(x => x.Voucher).WithMany(x => x.Productss).HasForeignKey(x => x.IdVoucher);
            //builder.HasOne(x => x.Size).WithMany(x => x.Productss).HasForeignKey(x => x.SizeID);


        }
    }
}
