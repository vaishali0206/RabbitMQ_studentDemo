using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Student_Records.Data
{
    public interface IStudentDbContext
    {
        DbSet<Student> Student { get; set; }

        Task<int> SaveChangesAsync();
    }
}
