using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class EfTestDbContext : DbContext
{
    private readonly ILoggerFactory? _loggerFactory;
#nullable disable
    public DbSet<Parent> Parents { get; set; }
#nullable enable

    public EfTestDbContext(ILoggerFactory? loggerFactory=null)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder opts)
    {
        opts
            .UseSqlite("Filename=test.db", o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));
            // .UseSqlServer(
            //     "yadayada",
            //     o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery)
            // );
        if (_loggerFactory != null) {
            opts.UseLoggerFactory(_loggerFactory);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Parent>(conf => {
            conf.HasKey(x => x.Id);

            conf.OwnsOne(x => x.Child, c => {
                c.Property(y => y.Optional).IsRequired(false);
                c.Property(y => y.HasFlag).IsRequired(true);
            });
        });
    }
}
