using Microsoft.EntityFrameworkCore;

namespace KomgrichApi.Models
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {

        }
        public DbSet<Students> Student {get;set;}
    }
}