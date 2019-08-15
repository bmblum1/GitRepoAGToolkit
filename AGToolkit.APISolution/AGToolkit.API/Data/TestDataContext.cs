using Microsoft.EntityFrameworkCore;
using System;

namespace AGToolkit.API.Data
{
    public class TestDataContext : DbContext
    {

        [ThreadStatic]
        protected static TestDataContext current;
        public static TestDataContext Current()
        {
            if (current == null)
                current = new TestDataContext();

            return current;
        }

        public TestDataContext() { }
        public TestDataContext(DbContextOptions<TestDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestData> TestData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-76B01B4\SQLEXPRESS;Initial Catalog=AGToolkitData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestData>(entity =>
            { });
        }
    }
}
