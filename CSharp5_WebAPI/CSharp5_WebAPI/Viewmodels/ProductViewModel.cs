using CSharp5_Share.Models;

namespace CSharp5_WebAPI.Viewmodels
{
    public class ProductViewModel
    {
        public Guid ProductID { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? ProducerID { get; set; }
        public Guid? ChefID { get; set; }
        public Guid? IdVoucher { get; set; }
        public int PercentageDiscount { get; set; }
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public int? EntryPrice { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public DateTime? Expired { get; set; }
        public DateTime? ImPortDate { get; set; }
        public int? Price { get; set; }
        public int? Status { get; set; }
        public string? Desciption { get; set; }
        public int? LastPrice => (int)(Price * PercentageDiscount)/100;
    }
}
