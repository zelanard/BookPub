using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookPubDB.Data;

/// <include file='Documentation/Data/PublisherContext.xml' path='doc/publishercontext/member[@name="T:BookPubDB.Data.PublisherContext"]' />
public class PublisherContext : DbContext
{
    /// <include file='Documentation/Data/PublisherContext.xml' path='doc/publishercontext/member[@name="C:BookPubDB.Data.PublisherContext"]' />
    public PublisherContext() { }

    /// <include file='Documentation/Data/PublisherContext.xml' path='doc/publishercontext/member[@name="P:BookPubDB.Data.PublisherContext.Authors"]' />
    public DbSet<Author> Authors { get; set; }

    /// <include file='Documentation/Data/PublisherContext.xml' path='doc/publishercontext/member[@name="P:BookPubDB.Data.PublisherContext.Books"]' />
    public DbSet<Book> Books { get; set; }

    /// <include file='Documentation/Data/PublisherContext.xml' path='doc/publishercontext/member[@name="P:BookPubDB.Data.PublisherContext.Artists"]' />
    public DbSet<Artist> Artists { get; set; }

    /// <include file='Documentation/Data/PublisherContext.xml' path='doc/publishercontext/member[@name="P:BookPubDB.Data.PublisherContext.Covers"]' />
    public DbSet<Cover> Covers { get; set; }

    /// <include file='Documentation/Data/PublisherContext.xml' path='doc/publishercontext/methods/member[@name="M:BookPubDB.Data.PublisherContext.OnConfiguring"]' />
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