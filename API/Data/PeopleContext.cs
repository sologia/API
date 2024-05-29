using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sharedmodels;

namespace API.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) 
        {
            
        }
        public DbSet<Person> People { get; set; }
    }
}
