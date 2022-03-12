using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Teste.Capta.API.Models;
using Teste.Capta.API.Data;
using Microsoft.Data.SqlClient;

namespace Teste.Capta.API.Controllers
{
    public class SituacoesClientesController : Controller
    {
        private readonly Contexto _contexto;
        private RetornoDTO _retorno;

        public SituacoesClientesController(Contexto contexto)
        {
            _contexto = contexto;
            _retorno = new RetornoDTO();
            _retorno.success = true;
        }

        [Route("api/clientes/situacoes")]
        public RetornoDTO Get()
        {
            var situacoesClientes = _contexto.ClientesSituacoes.FromSqlRaw<ClienteSituacao>($"ListarSituacoesClientes");
            _retorno.data = situacoesClientes;

            return _retorno;
        }
    }
}
