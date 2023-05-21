using CSharp5_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.Desciption).HasColumnType("nvarchar(1000)");
        }
    }
}
