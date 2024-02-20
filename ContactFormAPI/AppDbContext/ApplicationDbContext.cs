using ContactFormAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactFormAPI.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ContactForm> ContactForms { get; set; }
    }
}
