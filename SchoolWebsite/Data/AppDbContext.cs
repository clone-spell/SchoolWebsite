using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolWebsite.Models;

namespace SchoolWebsite.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Subscribe> Subcribes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
