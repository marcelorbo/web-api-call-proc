using System.ComponentModel.DataAnnotations;

namespace Teste.Capta.API.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Sexo { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdSituacaoCliente { get; set; }
    }
}
