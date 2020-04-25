using System;
using System.Data.Entity;
using System.Web;

namespace ZooTycoon.Data
{
    public class ZooTycoonContext : DbContext
    {
        public ZooTycoonContext() : base("DefaultConnection")
        {
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Zookeeper> Zookeepers { get; set; }
        //public DbSet<Customer> Customers { get; set; }
    }
}