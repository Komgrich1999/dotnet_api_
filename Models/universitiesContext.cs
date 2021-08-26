using Microsoft.EntityFrameworkCore;

namespace KomgrichApi.Models
{
    public class universitiesContext : DbContext
    
    {
        public universitiesContext(DbContextOptions<universitiesContext> options)
            :base(options)
        {

        }   

        public DbSet<universities> universitie {get; set;}
    }
}