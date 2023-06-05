namespace CSharp5_Share.Models
{
    public class CartDetail
    {
        public Guid CDID { get; set; }
        public Guid UserID { get; set; }
        public Guid? ProductID { get; set; }
        public Guid? ComboID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ToTal { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Products Products { get; set; }
        public virtual Combo Combo { get; set; }
    }
}
