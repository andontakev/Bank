using BankSample1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankSample1.Data
{
    public class BankContext : DbContext
    {
        //(localdb)\\MSSQLLocalDB Data Source=.;
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Banks;Integrated Security=True";
        public DbSet<Bank> Banks { get; set; }
        public BankContext(): base()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
