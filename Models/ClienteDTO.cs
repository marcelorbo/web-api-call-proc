namespace Teste.Capta.API.Models
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Sexo { get; set; }
        public int IdTipoCliente { get; set; }
        public string? TipoCliente { get; set; }
        public int IdSituacaoCliente { get; set; }
        public string? SituacaoCliente { get; set; }
    }
}
