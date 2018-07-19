using Microsoft.EntityFrameworkCore;

namespace ResumeAPI.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CVContent> CVContent { get; set; }
        public DbSet<Candidate> Candidate { get; set; }

        public DataContext(DbContextOptions<DataContext> context) : base(context)
        {

        }


    }
}
