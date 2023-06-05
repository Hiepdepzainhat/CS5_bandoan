namespace CSharp5_Share.Models
{
    public class Categories
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public virtual IEnumerable<Products> Productss { get; set; }
    }
}
