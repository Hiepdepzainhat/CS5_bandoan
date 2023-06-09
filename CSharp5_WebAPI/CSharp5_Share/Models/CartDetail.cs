using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class CartDetail
    {
        [Key]
        public Guid CDID { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? ToTal { get; set; }
        public virtual Cart? Cart { get; set; }
        public virtual Products? Products { get; set; }
        public virtual Combo? Combo { get; set; }
    }
}
