using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.PostID);
            builder.Property(x => x.CreateDate).HasColumnType("DateTime").IsUnicode();
            builder.Property(x => x.TiTlePost).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Content).HasColumnType("nvarchar(2000)");
            builder.Property(x => x.ImgPost).HasColumnType("nvarchar(1000)");
        }
    }
}
