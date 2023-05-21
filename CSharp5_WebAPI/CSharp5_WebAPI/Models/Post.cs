namespace CSharp5_WebAPI.Models
{
    public class Post
    {
        public Guid PostID { get; set; }
        public DateTime CreateDate { get; set; }
        public string TiTlePost  { get; set; }
        public string Content { get; set; }
        public string  ImgPost { get; set; }
    }
}
