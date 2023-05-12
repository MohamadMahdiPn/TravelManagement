using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelManagement.Infrastructure.Ef.Models;

namespace TravelManagement.Infrastructure.Ef.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<TravelCheckListReadModel>, IEntityTypeConfiguration<TravelerItemReadModel>
{
    public void Configure(EntityTypeBuilder<TravelCheckListReadModel> builder)
    {
        builder.ToTable("TravelCheckList");
        builder.HasKey(pl => pl.Id);

        builder
            .Property(pl => pl.Destination)
            .HasConversion(l => l.ToString(), l => DestinationReadModel.Create(l));

        builder
            .HasMany(pl => pl.Items)
            .WithOne(pi => pi.TravelCheckList);
    }

    public void Configure(EntityTypeBuilder<TravelerItemReadModel> builder)
    {
        builder.ToTable("TravelerItems");
    }
}