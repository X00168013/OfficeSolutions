using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeSolutions.Models
{
    public class OfficeSolutionsContext: DbContext
    {
        public DbSet<StationaryItem> StationaryItems { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Shop> Shops { get; set; }


        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=HomeOfficeSolutions;Trusted_Connection=False;";


        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
