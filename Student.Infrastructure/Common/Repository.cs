using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Student.Domain.Common;
using Student.Domain.Exceptions;
using Student.Infrastructure.Context;

namespace Student.Infrastructure.Common
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        // Inject AppDbContext
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Add entity
        public async Task<T> AddAsync(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        // Find entities by predicate
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _appDbContext.Set<T>().Where(predicate).ToListAsync();
        }

        // Get all entities
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        // Get entity by id
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        // Remove entity
        public async Task RemoveAsync(T? entity)
        {
            var id = entity?.Id;
            var original = await _appDbContext.Set<T>().FindAsync(id);

            if (original is null) throw new NotFoundException($"Student with Id={id} Not Found");

            if (entity != null) _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        // Update entity
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }

            var id = entity.Id;
            var original = await _appDbContext.Set<T>().FindAsync(id);

            if (original is null) throw new NotFoundException($"Student with Id={id} Not Found");

            _appDbContext.Entry(original).CurrentValues.SetValues(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}