namespace CSharp5_Share.Models
{
    public class Bill
    {
        public Guid BillID { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserID { get; set; }
        public int Status { get; set; }
        public int Price { get; set; }
        public virtual ICollection<BillDetail> BillDetail { get; set; }
        public virtual User User { get; set; }
    }
}
