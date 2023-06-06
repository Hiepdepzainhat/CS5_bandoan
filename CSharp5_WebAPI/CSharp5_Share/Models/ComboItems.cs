namespace CSharp5_Share.Models
{
    public class ComboItems
    {
        public Guid ComboItemID { get; set; }
        public Guid ProductID { get; set; }
        public Guid? ComboID { get; set; }
        public int Price { get; set; }
        public virtual Combo Combo { get; set; }
        public virtual Products Products { get; set; }
    }
}
