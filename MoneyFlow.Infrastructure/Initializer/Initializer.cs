using Microsoft.EntityFrameworkCore;
using MoneyFlow.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Infrastructure.Initializer
{
    public class Initializer
    {
        private readonly MoneyFlowDbContext _context;

        public Initializer(MoneyFlowDbContext context) { _context = context; }

        public async Task InitializeDb(MoneyFlowDbContext ctx)
        {
            await ctx.Database.MigrateAsync();
        }
    }
}
