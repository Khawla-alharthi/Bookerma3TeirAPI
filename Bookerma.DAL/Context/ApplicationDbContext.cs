using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookerma.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookerma.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
        }

        // Define DbSet properties for your entities
        public DbSet<Book> Books { get; set; }

    }
}
