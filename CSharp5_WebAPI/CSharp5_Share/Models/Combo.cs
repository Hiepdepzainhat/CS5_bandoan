namespace CSharp5_Share.Models
{
    public class Combo
    {
        public Guid ComboID { get; set; }
        public string ComboName { get; set; }
        public string ImgCombo { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public virtual List<ComboItems> ComboItems { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; } 
    }
}
