using ApiMarketHub.Domain.SideEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMarketHub.Infrastructure.Persistence.Command.SideEntities;
internal class PosterConfiguration : IEntityTypeConfiguration<Poster>
{
    public void Configure(EntityTypeBuilder<Poster> builder)
    {
        builder.Property(b => b.ImageName)
            .HasMaxLength(120).IsRequired();

        builder.Property(b => b.Link)
            .HasMaxLength(500).IsRequired();
    }
}