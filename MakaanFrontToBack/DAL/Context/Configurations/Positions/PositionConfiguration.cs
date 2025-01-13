using MakaanFrontToBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakaanFrontToBack.DAL.Context.Configurations.Positions;

public class PositionConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.Property(x => x.Name)
          .IsRequired()
          .HasMaxLength(30);
    }
}
