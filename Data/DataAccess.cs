using ST10115884_MashuduLuvhengo_POE_TASK1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST10115884_MashuduLuvhengo_POE_TASK1.Data
{
    public class DataAccess : DbContext
    {
        public DataAccess(DbContextOptions<DataAccess> options)
           : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Disaster> Disaster { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Monetary> Monetary { get; set; }

    }
}
