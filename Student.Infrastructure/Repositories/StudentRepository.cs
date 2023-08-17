using Student.Domain.Entities;
using Student.Domain.Interfaces.Repositories;
using Student.Infrastructure.Common;
using Student.Infrastructure.Context;

namespace Student.Infrastructure.Repositories;

public class StudentRepository : Repository<StudentEntity>, IStudentRepository
{   
    // Inject AppDbContext
    public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}