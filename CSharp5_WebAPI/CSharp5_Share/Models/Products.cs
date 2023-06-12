using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CSharp5_Share.Models
{
    public class Products
    {
        [Key]
        public Guid ProductID { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? ProducerID { get; set; }
        public Guid? ChefID { get; set; }
        public Guid? IdVoucher { get; set; }
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public int? EntryPrice { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public DateTime? Expired { get; set; }
        public DateTime? ImPortDate { get; set; }
        public int? Price { get; set; }
        public int? Status { get; set; }
        public string? Desciption { get; set; }
        public virtual Producer? Producer { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual Categories? Categories { get; set; }
        public virtual Chef? Chef { get; set; }
        public virtual ICollection<ComboItems>? ComboItems { get; set; }
        public virtual ICollection<CartDetail>? CartDetails { get; set; }
        public virtual ICollection<BillDetail>? BillDetails { get; set; }


    }
}
