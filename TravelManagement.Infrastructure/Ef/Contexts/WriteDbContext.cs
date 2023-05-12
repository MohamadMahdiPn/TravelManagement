using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Infrastructure.Ef.Config;

namespace TravelManagement.Infrastructure.Ef.Contexts;


internal sealed class WriteDbContext : DbContext
{
    public DbSet<TravelCheckList> TravelCheckLists { get; set; }




    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TravelCheckList");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<TravelCheckList>(configuration);
        modelBuilder.ApplyConfiguration<TravelerItem>(configuration);
    }
}