﻿namespace CSharp5_WebAPI.Models
{
    public class BillDetail
    {
        public Guid  BillDetailID { get; set; }
        public  Guid BillID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Products Products { get; set; }
    }
}
