﻿namespace CSharp5_WebAPI.Models
{
    public class Chef
    {
        public Guid ChefID { get; set; }
        public string ChefName { get; set; }
        public string ChefDescription { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }
    }
}
