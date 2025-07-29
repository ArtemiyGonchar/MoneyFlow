using Microsoft.EntityFrameworkCore;
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
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MoneyFlowDbContext _ctx;

        public Repository(MoneyFlowDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public async Task<Guid> CreateAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid> UpdateAsync(T entity)
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _ctx.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return false;
            }
            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
