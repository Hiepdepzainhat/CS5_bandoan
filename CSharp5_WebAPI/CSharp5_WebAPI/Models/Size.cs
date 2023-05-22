namespace CSharp5_WebAPI.Models
{
    public class Size
    {
        public Guid SizeID { get; set; }
        public string SizeName { get; set; }
        public string Desciption { get; set; }
        public int MultiplePrice { get; set; }
        public virtual IEnumerable<Products> Productss { get; set; }
    }
}
