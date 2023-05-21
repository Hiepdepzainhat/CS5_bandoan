using CSharp5_WebAPI.Models;
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
        public DbSet<Products> Productss { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<National> Nationals { get; set; }
        public DbSet<Chef> Chefs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-DAV1LO0Q\SQLEXPRESS;Initial Catalog=CS5_DoAnNhanh;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
