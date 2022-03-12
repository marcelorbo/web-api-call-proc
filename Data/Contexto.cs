using Teste.Capta.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Teste.Capta.API.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteSituacao> ClientesSituacoes { get; set; }
        public DbSet<ClienteTipo> ClientesTipos { get; set; }
        public DbSet<ClienteDTO> ClientesDTO { get; set; }

    }
}
