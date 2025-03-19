using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookPubDB.Data
{
    /// <include file='Documentation/Data/IdentityContext.xml' path='doc/identitycontext/member[@name="T:BookPubDB.Data.IdentityContext"]' />
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        /// <include file='Documentation/Data/IdentityContext.xml' path='doc/identitycontext/member[@name="C:BookPubDB.Data.IdentityContext"]' />
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        /// <include file='Documentation/Data/IdentityContext.xml' path='doc/identitycontext/methods/member[@name="M:BookPubDB.Data.IdentityContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)"]' />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        /// <include file='Documentation/Data/IdentityContext.xml' path='doc/identitycontext/methods/member[@name="M:BookPubDB.Data.IdentityContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)"]' />
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
}