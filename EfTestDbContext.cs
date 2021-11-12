using Microsoft.EntityFrameworkCore;

public class EfTestDbContext : DbContext
{
#nullable disable
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
#nullable enable

    protected override void OnConfiguring(DbContextOptionsBuilder opts)
    {
        opts
            .UseSqlite("Filename=test.db", o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery))
            .EnableSensitiveDataLogging();
        // opts.EnableSensitiveDataLogging();
        // opts.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ShoppingCart>(conf =>
        {
            conf.OwnsOne(x => x.BillingInformation, b => {
                b.Property(y => y.Name).IsRequired(false);
                b.Property(y => y.Address).IsRequired(false);
            });

            conf.OwnsOne(x => x.DeliveryInformation, d => {
                d.Property(y => y.Name).IsRequired(false);
                d.Property(y => y.Address).IsRequired(false);
                d.Property(y => y.Floor).IsRequired(false);
            });

            conf.ToTable("ShoppingCart");
        });
    }
}
