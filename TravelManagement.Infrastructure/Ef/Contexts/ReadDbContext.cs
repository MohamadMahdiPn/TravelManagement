using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TravelManagement.Infrastructure.Ef.Config;
using TravelManagement.Infrastructure.Ef.Models;
namespace TravelManagement.Infrastructure.Ef.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<TravelCheckListReadModel> TravelCheckList { get; set; }



    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TravelCheckList");

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<TravelCheckListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<TravelerItemReadModel>(configuration);
    }
}