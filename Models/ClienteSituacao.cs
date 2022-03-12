using System.ComponentModel.DataAnnotations;

namespace Teste.Capta.API.Models
{
    public class ClienteSituacao
    {
        [Key]
        public int Id { get; set; }
        public string? Descricao { get; set; }
    }
}
