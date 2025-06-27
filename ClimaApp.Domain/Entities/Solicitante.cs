namespace ClimaApp.Domain.Entities;

public class Solicitante
{
    public int Id { get; set; }
    public string Nome { get; set; }

    #region Relacionamento

    public ICollection<Relatorio> Relatorios { get; set; }

    #endregion
}