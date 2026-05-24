using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;

namespace SalesMgrSystem.Tests.Infrastructure;

public static class TestDbContextFactory
{
    public static string NewDatabaseName() => $"SalesMgrSystemTests_{Guid.NewGuid()}";

    public static SalesMgrContext CreateContext(string databaseName)
    {
        var options = new DbContextOptionsBuilder<SalesMgrContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;

        return new InMemorySalesMgrContext(options);
    }

    private sealed class InMemorySalesMgrContext(DbContextOptions<SalesMgrContext> options)
        : SalesMgrContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Intentionally empty: tests provide InMemory provider through options.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Override views to be treated as tables in InMemory database
            modelBuilder.Entity<VwProductSale>(entity =>
            {
                entity.HasKey(e => e.ProductName);
                entity.ToTable("VwProductSales");
            });

            modelBuilder.Entity<VwSalesSummary>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.ToTable("VwSalesSummaries");
            });
        }
    }
}
