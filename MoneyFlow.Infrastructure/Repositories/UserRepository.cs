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
    public class UserRepository : Repository<UserProfile>, IUserProfileRepository
    {
        private readonly MoneyFlowDbContext _ctx;

        public UserRepository(MoneyFlowDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
