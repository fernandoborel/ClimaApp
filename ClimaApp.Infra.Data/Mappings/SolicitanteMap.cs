using ClimaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClimaApp.Infra.Data.Mappings;

public class SolicitanteMap : IEntityTypeConfiguration<Solicitante>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Solicitante> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Nome)
            .IsRequired()
            .HasMaxLength(100);
    }
}