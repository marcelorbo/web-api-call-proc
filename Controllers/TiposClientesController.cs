using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Teste.Capta.API.Models;
using Teste.Capta.API.Data;
using Microsoft.Data.SqlClient;

namespace Teste.Capta.API.Controllers
{
    public class TiposClientesController : Controller
    {
        private readonly Contexto _contexto;
        private RetornoDTO _retorno;

        public TiposClientesController(Contexto contexto)
        {
            _contexto = contexto;
            _retorno = new RetornoDTO();
            _retorno.success = true;
        }

        [Route("api/clientes/tipos")]
        public RetornoDTO Get()
        {
            var tiposClientes = _contexto.ClientesTipos.FromSqlRaw<ClienteTipo>($"ListarTiposClientes");
            _retorno.data = tiposClientes;

            return _retorno;
        }

    }
}
