using System.ComponentModel.DataAnnotations;

namespace CSharp5_Share.Models
{
    public class Combo
    {
        [Key]
        public Guid ComboID { get; set; }
        public string ComboName { get; set; }
        public string ImgCombo { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
    }
}
