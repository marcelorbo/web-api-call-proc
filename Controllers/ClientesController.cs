using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Teste.Capta.API.Models;
using Teste.Capta.API.Data;
using Microsoft.Data.SqlClient;

namespace Teste.Capta.API.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Contexto _contexto;
        private RetornoDTO _retorno;

        public ClientesController(Contexto contexto)
        {
            _contexto = contexto;

            _retorno = new RetornoDTO();
            _retorno.success = true;
        }

        [HttpGet]
        [Route("api/clientes")]
        public RetornoDTO Get()
        {
            try
            {
                var clientes = _contexto.ClientesDTO.FromSqlRaw<ClienteDTO>($"ListarClientes");
                _retorno.data = clientes;
            }
            catch (SqlException exSQL) 
            {
                _retorno.success = false;
                _retorno.message = exSQL.Message;
            }
            catch (Exception ex)
            {
                _retorno.success = false;
                _retorno.message = ex.Message;
            }

            return _retorno;
        }

        [HttpPost]
        [Route("/api/clientes")]
        public RetornoDTO Post([FromBody] Cliente cliente)
        {
            try
            {
                var clienteComMesmoCPF = _contexto.ClientesDTO.FromSqlRaw<ClienteDTO>("EXECUTE [ListarClientes] @CPF",
                    new SqlParameter("@CPF", cliente.CPF)
                );

                if (clienteComMesmoCPF.ToList<ClienteDTO>().Count() > 0) {
                    _retorno.success = false;
                    _retorno.message = "O CPF informado já existe em nosso banco de dados";
                    return _retorno;
                }

                _contexto.Database.ExecuteSqlRaw($"EXECUTE [SalvarCliente] '{cliente.Nome}', '{cliente.CPF}', '{cliente.Sexo}', {cliente.IdTipoCliente}, {cliente.IdSituacaoCliente}");
            }
            catch (SqlException exSQL)
            {
                _retorno.success = false;
                _retorno.message = exSQL.Message;
            }
            catch (Exception ex)
            {
                _retorno.success = false;
                _retorno.message = ex.Message;
            }

            return _retorno;
        }

        [HttpPut]
        [Route("/api/clientes")]
        public RetornoDTO Put([FromBody] Cliente cliente)
        {
            try
            {
                var clienteComMesmoCPF = _contexto.ClientesDTO.FromSqlRaw<ClienteDTO>("EXECUTE [ListarClientes] @CPF",
                    new SqlParameter("@CPF", cliente.CPF)
                );

                if (clienteComMesmoCPF.ToList<ClienteDTO>().Count() > 0 &&
                        clienteComMesmoCPF.ToList<ClienteDTO>()[0].Id != cliente.Id
                    )
                {
                    _retorno.success = false;
                    _retorno.message = "O CPF informado já existe em nosso banco de dados";
                    return _retorno;
                }

                _contexto.Database.ExecuteSqlRaw($"EXECUTE [AtualizarCliente] {cliente.Id}, '{cliente.Nome}', '{cliente.CPF}', '{cliente.Sexo}', {cliente.IdTipoCliente}, {cliente.IdSituacaoCliente}");
            }
            catch (SqlException exSQL)
            {
                _retorno.success = false;
                _retorno.message = exSQL.Message;
            }
            catch (Exception ex)
            {
                _retorno.success = false;
                _retorno.message = ex.Message;
            }

            return _retorno;
        }

        [HttpDelete]
        [Route("/api/clientes/{id}")]
        public RetornoDTO Delete(int Id)
        {
            try
            {
                _contexto.Database.ExecuteSqlRaw($"EXECUTE [DeletarCliente] {Id}");
            }
            catch (SqlException exSQL)
            {
                _retorno.success = false;
                _retorno.message = exSQL.Message;
            }
            catch (Exception ex)
            {
                _retorno.success = false;
                _retorno.message = ex.Message;
            }

            return _retorno;
        }

    }
}