using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGToolkit.API.Data
{
    public class TestDataContext : DbContext
    {
        public TestDataContext(DbContextOptions<TestDataContext> ctx) : base(ctx) { }
        
        public virtual DbSet<TestData> TestData { get; set; }
    }
}
