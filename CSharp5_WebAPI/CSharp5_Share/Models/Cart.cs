using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class Cart
    {
        [Key]
        public Guid UserID { get; set; }
        public string Desciption { get; set; }
        public virtual User User { get; set; }
    }
}
