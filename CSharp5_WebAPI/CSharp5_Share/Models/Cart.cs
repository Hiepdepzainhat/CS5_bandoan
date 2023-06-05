namespace CSharp5_Share.Models
{
    public class Cart
    {
        public Guid UserID { get; set; }
        public string Desciption { get; set; }
        public virtual User User { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }
    }
}
