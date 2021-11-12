using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .SetMinimumLevel(LogLevel.Trace)
        .AddConsole();
});
ILogger logger = loggerFactory.CreateLogger<Program>();
logger.LogDebug("Starting...");

using (var ctx = new EfTestDbContext())
{
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
    // await ctx.Database.MigrateAsync();
}

using (var ctx = new EfTestDbContext())
{
    var shoppingCart1 = new ShoppingCart("John Doe");
    ctx.ShoppingCarts.Add(shoppingCart1);
    await ctx.SaveChangesAsync();

    shoppingCart1.SetBilling(new BillingInformation("Aretha Franklin", "23 Elm Street"));
    shoppingCart1.SetDelivery(new DeliveryInformation("Aretha Franklin", "23 Elm Street", null));
    await ctx.SaveChangesAsync();

    var shoppingCart2 = new ShoppingCart("John Doe");
    ctx.ShoppingCarts.Add(shoppingCart2);
    await ctx.SaveChangesAsync();

    shoppingCart2.SetBilling(new BillingInformation("Aretha Franklin", "23 Elm Street"));
    await ctx.SaveChangesAsync();
}

// ----------------

using (var ctx = new EfTestDbContext())
{
    foreach (var cart in ctx.ShoppingCarts)
    {
        logger.LogInformation($"Cart: {cart.Id}");
        logger.LogInformation($"Salesperson: {cart.Salesperson}");
        if (cart.BillingInformation != null)
        {
            logger.LogInformation($"Billing: {cart.BillingInformation.Name}, {cart.BillingInformation.Address}");
        }
        if (cart.DeliveryInformation != null)
        {
            logger.LogInformation($"Delivery: {cart.DeliveryInformation.Name}, {cart.DeliveryInformation.Address} floor: {cart.DeliveryInformation.Floor?.ToString() ?? "n/a"}");
        }
    }
}


// logger.LogInformation("Info Log");
// logger.LogWarning("Warning Log");
// logger.LogError("Error Log");
// logger.LogCritical("Critical Log");