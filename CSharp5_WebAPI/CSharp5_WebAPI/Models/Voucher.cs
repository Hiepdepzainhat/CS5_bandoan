namespace CSharp5_WebAPI.Models
{
    public class Voucher
    {
        public Guid VoucherID { get; set; }
        public string VoucherName { get; set; }
        public int PercentageDiscount { get; set; }
        public virtual IEnumerable<Products> Productss { get; set; }
    }
}
