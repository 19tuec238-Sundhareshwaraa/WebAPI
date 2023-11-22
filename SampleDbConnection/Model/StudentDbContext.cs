using Microsoft.EntityFrameworkCore;

namespace SampleDbConnection.Model
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options) { }

        public DbSet<StudentDetails> StudentDetailsTraining { get; set; }

    }
}
