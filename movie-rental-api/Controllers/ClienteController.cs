using Microsoft.AspNetCore.Mvc;
using movie_rental_api.Context;
using movie_rental_api.Entities;
using System.Linq;
using System.Net;

namespace movie_rental_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlugueisController : ControllerBase
    {
        //Construtor do context
        private readonly AlugueisContext _context;
        public AlugueisController(AlugueisContext context) 
        {
            _context = context;
        }

        //Métodos

        //Cadastrar cliente
        [HttpPost]
        [Route("CadastrarCliente")]
        public IActionResult Criar(Cliente cliente)
        {
            //Restrição de e-mail duplicado, 409 Conflict
            if (_context.Clientes.Any(x => x.Email == cliente.Email))
            {
                return Conflict(new { message = "Opa! Este endereço de e-mail já está cadastrado." });
            }
        _context.Add(cliente);
        _context.SaveChanges();
        return Ok(cliente);
        }

        //Buscar por Id
        [HttpGet]
        [Route("BuscarId")]
        public IActionResult BuscarPorID(int Id)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == Id);
            return Ok(cliente);
        }

        //Buscar por Nome ~ buscar por inicial?
        [HttpGet]
        [Route("BuscarNome/")]
        public IActionResult BuscarPorNome([FromQuery]string nome)
        {
            var cliente = _context.Clientes.Where(x => x.Nome.Contains(nome)).ToList();
            return Ok(cliente);
        }

        //Deletar registro    
        [HttpDelete]
        [Route("DeletarCliente/{Id}")]
        public IActionResult DeletarCliente([FromRoute]int Id)

        {
            var del = _context.Clientes.FirstOrDefault(d => d.Id == Id);
            _context.Clientes.Remove(del);
            _context.SaveChanges();
            return NoContent();
        }

        //Editar Telefone
        [HttpPut]
        [Route("AtualizarTelefone")]
        public IActionResult AtualizarTelefone(int Id, [FromBody]Cliente cliente)
        {
            var tel = _context.Clientes.FirstOrDefault(t => t.Id == Id);
            tel.Telefone = cliente.Telefone;
            _context.SaveChanges();
            return Ok(tel);
        }
    }
}
