public class RelatorioResponse
{
    public int Id { get; set; }
    public string Cidade { get; set; }
    public string Pais { get; set; }
    public decimal Temperatura { get; set; }
    public string Condicao { get; set; }
    public decimal VelocidadeVento { get; set; }
    public DateTime DataHora { get; set; }

    public int SolicitanteId { get; set; }
}