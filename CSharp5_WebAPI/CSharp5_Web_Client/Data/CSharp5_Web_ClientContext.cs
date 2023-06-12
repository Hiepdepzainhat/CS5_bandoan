using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSharp5_Share.Models;

namespace CSharp5_Web_Client.Data
{
    public class CSharp5_Web_ClientContext : DbContext
    {
        public CSharp5_Web_ClientContext (DbContextOptions<CSharp5_Web_ClientContext> options)
            : base(options)
        {
        }

        public DbSet<CSharp5_Share.Models.User> User { get; set; } = default!;

        public DbSet<CSharp5_Share.Models.Cart>? Cart { get; set; }

        public DbSet<CSharp5_Share.Models.CartDetail>? CartDetail { get; set; }
    }
}
