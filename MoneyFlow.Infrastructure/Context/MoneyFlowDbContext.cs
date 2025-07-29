using Microsoft.EntityFrameworkCore;
using MoneyFlow.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Infrastructure.Context
{
    public class MoneyFlowDbContext : DbContext
    {
        public MoneyFlowDbContext(DbContextOptions<MoneyFlowDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Applying configurations for entities
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
