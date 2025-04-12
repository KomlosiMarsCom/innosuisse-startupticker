using Innosuisse.Startupticker.WebApp.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Innosuisse.Startupticker.WebApp.Server.Data
{
    public sealed class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public required DbSet<Startup> Startups { get; set; } = null!;
    }
}
