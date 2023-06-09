using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class BillDetail
    {
        [Key]
        public Guid BillDetailID { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public virtual Bill? Bill { get; set; }
        public virtual Products? Products { get; set; }
    }
}
