using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySQL(@"server=localhost;user=root;password=root;database=dressDb;");
        base.OnConfiguring(optionsBuilder);
    }
}