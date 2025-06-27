using ClimaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClimaApp.Infra.Data.Mappings;

public class RelatorioMap : IEntityTypeConfiguration<Relatorio> 
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Relatorio> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Cidade)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(r => r.Pais)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(r => r.Temperatura)
            .IsRequired();

        builder.Property(r => r.Condicao)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(r => r.VelocidadeVento)
            .IsRequired();

        builder.Property(r => r.DataHora)
            .IsRequired();
    }
}