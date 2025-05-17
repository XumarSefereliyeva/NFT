using Microsoft.EntityFrameworkCore;
using NFTSolution.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTSolution.DAL.Contexts
{
   public class AppDbContext:DbContext
    {
        private readonly string _connection = @"Server=DESKTOP-OB068TR\SQLEXPRESS01;Database=;Trusted_connection=True;TrustServerCertificate=True";

        public DbSet<Market> markets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
