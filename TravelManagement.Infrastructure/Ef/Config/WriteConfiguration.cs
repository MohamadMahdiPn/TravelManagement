using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Infrastructure.Ef.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<TravelCheckList>, IEntityTypeConfiguration<TravelerItem>
{
    public void Configure(EntityTypeBuilder<TravelCheckList> builder)
    {
        builder.HasKey(pl => pl.Id);

        var destinationConverter = new ValueConverter<TravelerCheckListDestination, string>(l => l.ToString(),
            l => TravelerCheckListDestination.Create(l));

        var packingListNameConverter = new ValueConverter<TravelerCheckListName, string>(pln => pln.Value,
            pln => new TravelerCheckListName(pln));

        builder
            .Property(pl => pl.Id)
            .HasConversion(id => id.Value, id => new TravelerCheckListId(id));

        builder
            .Property(typeof(TravelerCheckListDestination), "_destination")
            .HasConversion(destinationConverter)
            .HasColumnName("Destination");

        builder
            .Property(typeof(TravelerCheckListName), "_name")
            .HasConversion(packingListNameConverter)
            .HasColumnName("Name");

        builder.HasMany(typeof(TravelerItem), "_items");

        builder.ToTable("TravelerCheckList");
    }

    public void Configure(EntityTypeBuilder<TravelerItem> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(pi => pi.Name);
        builder.Property(pi => pi.Quantity);
        builder.Property(pi => pi.IsTaken);
        builder.ToTable("TravelerItems");
    }
}