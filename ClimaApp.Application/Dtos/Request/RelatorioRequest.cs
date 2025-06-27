namespace ClimaApp.Application.Dtos.Request;

public class RelatorioRequest
{
    /// <summary>
    /// ID do solicitante que está requisitando o relatório. | exemplo: 1, 2, 3...
    /// </summary>
    public int SolicitanteId { get; set; }

    /// <summary>
    /// Define o tipo de cidade a ser consultada. | Exemplo: "Rio de Janeiro", "São Paulo", etc.
    /// </summary>
    public string Cidade { get; set; }
}