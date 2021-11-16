using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .SetMinimumLevel(LogLevel.Trace)
        .AddConsole();
});
ILogger logger = loggerFactory.CreateLogger<Program>();
logger.LogDebug("Starting...");

using (var ctx = new EfTestDbContext(loggerFactory))
{
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

using (var ctx = new EfTestDbContext(loggerFactory))
{
    var parent = new Parent { Child = new Dependent { HasFlag = true, Optional = "Opts" } };
    ctx.Parents.Add(parent);
    await ctx.SaveChangesAsync();

    parent.Child = new Dependent { HasFlag = true, Optional = "Opts" };
    await ctx.SaveChangesAsync(); // triggers the warning
}
