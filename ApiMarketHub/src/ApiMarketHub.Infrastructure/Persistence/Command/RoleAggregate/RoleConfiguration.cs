using ApiMarketHub.Domain.RoleAggregate;
using Microsoft.EntityFrameworkCore;

namespace ApiMarketHub.Infrastructure.Persistence.Command.RoleAggregate;
internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "role");
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(60);

        builder.OwnsMany(b => b.Permissions, option =>
        {
            option.ToTable("Permissions", "role");
        });
    }
}