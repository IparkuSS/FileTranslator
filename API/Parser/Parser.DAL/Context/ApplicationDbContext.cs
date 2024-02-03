using Microsoft.EntityFrameworkCore;
using Parser.DAL.Models;

namespace Parser.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FileDb> Files { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
