using FirstBookStore.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace FirstBookStore.DbData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}