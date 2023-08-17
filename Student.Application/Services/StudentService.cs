using Student.Application.Interfaces;
using Student.Domain.Entities;
using Student.Domain.Exceptions;
using Student.Domain.Interfaces.Repositories;
using System.Linq.Expressions;


namespace Student.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentEntity> AddAsync(StudentEntity entity)
        {
            return await _studentRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<StudentEntity> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student is null)
            {
                throw new NotFoundException($"Person with Id={id} Not Found");
            }

            return student;
        }

        public async Task<IEnumerable<StudentEntity>> FindAsync(Expression<Func<StudentEntity, bool>> predicate)
        {
            return await _studentRepository.FindAsync(predicate);
        }

        public async Task<StudentEntity> UpdateAsync(int id, StudentEntity entity)
        {
            if (id != entity.Id)
            {
                throw new BadRequestException($"The Id={id} not corresponding with Entity.Id={entity.Id}");
            }

            var person = await _studentRepository.GetByIdAsync(id);

            if (person is null)
            {
                throw new NotFoundException($"Student with Id={id} Not Found");
            }

            return (await _studentRepository.UpdateAsync(entity));
        }

        public async Task RemoveAsync(int id)
        {
            var person = await _studentRepository.GetByIdAsync(id);

            if (person is null)
            {
                throw new NotFoundException($"Student with Id={id} Not Found");
            }

            await _studentRepository.RemoveAsync(person);
        }
    }
}