using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class Voucher
    {
        [Key]
        public Guid VoucherID { get; set; }
        public string? VoucherName { get; set; }
        public int? PercentageDiscount { get; set; }
    }
}
