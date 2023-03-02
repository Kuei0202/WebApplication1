using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }
        public DbSet<Calendar_Table> Calendar_Table { get; set; } = default!;
        public DbSet<User_account> User_account { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar_Table>().ToTable("Calendar_Table");
            modelBuilder.Entity<User_account>().ToTable("AccountTable");
        }
    }
}
