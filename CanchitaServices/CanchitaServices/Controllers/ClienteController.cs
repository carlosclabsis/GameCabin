using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanchitaServices.Models.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaServices.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private IClienteRepository repositorio;
        public ClienteController(IClienteRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TCliente> Get()
        {
            return repositorio.Clientes;
        }

        // GET api/<controller>/5
        [HttpGet("{ClienteId}")]
        public TCliente Get(Guid ClienteID)
        {

            return repositorio.Clientes.Where(p => p.CliId == ClienteID).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TCliente cliente)
        {
            repositorio.SaveClient(cliente);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ClienteId}")]
        public IActionResult Put(Guid ClienteId, [FromBody]TCliente cliente)
        {
            cliente.CliId = ClienteId;
            repositorio.SaveClient(cliente);
            return Ok(true);
        }


        // DELETE api/<controller>/5
        [HttpDelete("{ClienteId}")]
        public IActionResult Delete(Guid ClienteId)
        {
            repositorio.DeleteCliente(ClienteId);
            return Ok(true);
        }
    }
}
