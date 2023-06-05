
using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CSharp5_WebAPI.Data
{
    public class CS5_DbContext : DbContext
    {
        public CS5_DbContext()
        {
            
        }
        public CS5_DbContext(DbContextOptions options) : base(options) { }
        public virtual  DbSet<Products> Productss { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        //public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<National> Nationals { get; set; }
        public virtual DbSet<Chef> Chefs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Combo> Combos { get; set; }
        public virtual DbSet<ComboItems> ComboItems { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
