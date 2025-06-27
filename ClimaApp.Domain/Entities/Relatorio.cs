using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaApp.Domain.Entities;

public class Relatorio
{
    public int Id { get; set; }
    public string Cidade { get; set; }
    public string Pais { get; set; }
    public decimal Temperatura { get; set; }
    public string Condicao { get; set; }
    public decimal VelocidadeVento { get; set; }
    public DateTime DataHora { get; set; }

    #region Relacionamento

    public int SolicitanteId { get; set; }

    [ForeignKey(nameof(SolicitanteId))]
    public Solicitante Solicitante { get; set; }
    
    #endregion
}