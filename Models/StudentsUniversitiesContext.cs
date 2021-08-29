using Microsoft.EntityFrameworkCore;

namespace KomgrichApi.Models
{
    public class StudentsUniversitiesContext : DbContext
    {
        public StudentsUniversitiesContext(DbContextOptions<StudentsUniversitiesContext> options)
            : base(options)
        {
            
        }

        public DbSet<StudentsUniversities> StudentsUniversitie {get;set;}
    }
}