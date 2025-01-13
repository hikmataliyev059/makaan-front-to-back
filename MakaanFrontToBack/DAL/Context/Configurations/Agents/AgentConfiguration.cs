using MakaanFrontToBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakaanFrontToBack.DAL.Context.Configurations.Agents
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.ImageUrl)
               .IsRequired(false)
               .HasMaxLength(300);

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Position)
                .WithMany(p => p.Agents)
                .HasForeignKey(a => a.PositionId);

            builder.Ignore(a => a.File);
        }
    }
}
