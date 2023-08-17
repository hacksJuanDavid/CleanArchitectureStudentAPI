using Student.Domain.Entities;
using System.Linq.Expressions;

namespace Student.Application.Interfaces
{
    public interface IStudentService
    {
        public Task<StudentEntity> AddAsync(StudentEntity entity);

        public Task<IEnumerable<StudentEntity>> GetAllAsync();

        public Task<StudentEntity> GetByIdAsync(int id);

        public Task<IEnumerable<StudentEntity>> FindAsync(Expression<Func<StudentEntity, bool>> predicate);

        public Task<StudentEntity> UpdateAsync(int id, StudentEntity entity);

        public Task RemoveAsync(int id);
    }
}