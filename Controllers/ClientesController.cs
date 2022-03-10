using CRUD_back.Models;
using CRUD_back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Clientes>>> GetCLientes()
        {
            try
            {
                var clientes = await _clientesService.GetClientes();
                return Ok(clientes);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ao obter alunos");
            }
        }

        [HttpGet("AlunosPorName")]
        public async Task<ActionResult<IAsyncEnumerable<Clientes>>> GetCLientesByName([FromQuery] string name)
        {
            try
            {
                var clientes = await _clientesService.GetClientesByName(name);
                if (clientes.Count() == 0)
                    return NotFound($"Não Existem clientes com o critério {name}");
                return Ok(clientes);
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }

        [HttpGet("{id:int}", Name = "GetClientes")]
        public async Task<ActionResult<IAsyncEnumerable<Clientes>>> GetClientes(int id)
        {
            try
            {
                var clientes = await _clientesService.GetClientes(id);
                if (clientes == null)
                    return NotFound($"Não Existem clientes com o id {id}");
                return Ok(clientes);
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Clientes clientes)
        {
            try
            {
                await _clientesService.CreateClientes(clientes);
                return CreatedAtRoute(nameof(GetClientes), new { id = clientes.Id }, clientes);
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Clientes clientes)
        {
            try
            {
                if (clientes.Id == id)
                {
                    await _clientesService.UpdateClientes(clientes);
                    return NoContent();
                }
                else
                {
                    return BadRequest("Dados invalidos");
                }
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var clientes = await _clientesService.GetClientes(id);
                if (clientes != null) {
                    await _clientesService.DeleteClientes(clientes);
                    return Ok($"O cliente de id={id} foi excluido com sucesso!!!");
                }

                else
                {
                    return NotFound($"Cliente com id={id} não foi encontrado no nosso banco de dados");
                }
            }
            catch
            {
                return BadRequest("Request invalido"); 
            }
        }
    }
}