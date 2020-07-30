using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext> opt) : base(opt)
        {

        }

        public DbSet<Institution> Institutions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}