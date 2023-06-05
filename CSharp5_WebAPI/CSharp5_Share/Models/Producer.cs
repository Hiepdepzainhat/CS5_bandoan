namespace CSharp5_Share.Models
{
    public class Producer
    {
        public Guid ProducerID { get; set; }
        public string ProducerName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Products> Productss { get; set; }
    }
}
