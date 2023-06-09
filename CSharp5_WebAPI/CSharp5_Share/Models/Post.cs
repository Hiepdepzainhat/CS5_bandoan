using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class Post
    {
        [Key]
        public Guid PostID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? TiTlePost { get; set; }
        public string? Content { get; set; }
        public string? ImgPost { get; set; }
    }
}
