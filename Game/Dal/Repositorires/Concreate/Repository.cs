using Dal.Context;
using Dal.Repositorires.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dal.Repositorires.Concreate
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class, new()
    {
        private readonly GameDbContext _context;

        public Repository(GameDbContext context)
        {
            _context = context;
            //this._dbSet = dbContext.Set<T>();
        }
        public async Task AddAsync(Tentity entity)
        {
            await _context.AddAsync(entity);
            //_context.AddAsync<Tentity>(entity);
            //_context.Set<Tentity>().AddAsync(entity);
            //_context.Entry(entity).State = EntityState.Added;


            await _context.SaveChangesAsync();

        }
        public List<Tentity> GetAll()
        {
            return _context.Set<Tentity>().ToList();

        }
        public async Task<Tentity> GetAsync(int id)
        {
            var entity = await _context.FindAsync<Tentity>(id);
            return entity;
        }

        public async Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> predicate)
        {
            var entity = await _context.Set<Tentity>().SingleOrDefaultAsync<Tentity>(predicate);
            return entity;
        }

        public async Task RemoveAsync(Tentity entity)
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();//gerek olamyabilir
        }

        public async Task UpdateAsync(Tentity entity)
        {
            _context.Update(entity);

            //_context.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();//gerek olmayabilir
        }
    }
}
