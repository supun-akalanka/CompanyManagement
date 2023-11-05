using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Data
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }

    }
}
