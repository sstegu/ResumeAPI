using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CVContent> CVContent { get; set; }

        public DataContext(DbContextOptions<DataContext> context) : base(context)
        {

        }


    }
}
