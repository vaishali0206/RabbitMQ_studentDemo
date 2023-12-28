using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Student_Records.Data
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
