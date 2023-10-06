using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRHD_FULL.Modelos;

namespace PRHD_FULL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<LaboratoryTest> LaboratoryTests { get; set; }
        public DbSet<Case> Cases { get; set; }

    }
}
