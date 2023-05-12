using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TravelManagement.Infrastructure.Ef.Config;
using TravelManagement.Infrastructure.Ef.Models;
namespace TravelManagement.Infrastructure.Ef.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<TravelerCheckListReadModel> TravelerCheckList { get; set; }



    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TravelerCheckList");

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<TravelerCheckListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<TravelerItemReadModel>(configuration);
    }
}