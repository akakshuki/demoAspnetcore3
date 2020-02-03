using System;
using System.Collections.Generic;
using System.Text;
using eShopSolutionData.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShopSolutionData.EF
{
    public class EShopDBContext: DbContext
    {
        private EShopDBContext(DbContextOptions options): base(options)
        {
            
        }
    public DbSet<Product> Products { get; set; }

    }
}
