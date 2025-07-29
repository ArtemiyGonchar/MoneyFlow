using MoneyFlow.Domain.Entities;
using MoneyFlow.Domain.Interfaces.Repositories;
using MoneyFlow.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MoneyFlowDbContext _ctx;

        public CategoryRepository(MoneyFlowDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
