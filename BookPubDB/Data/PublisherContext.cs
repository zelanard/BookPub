using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookPubDB.Data;

public class PublisherContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Cover> Covers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
          "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = H3_PublisherDB",
           b => b.MigrationsAssembly("BookPub")
        ).LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information)
        .EnableSensitiveDataLogging();
    }
}
