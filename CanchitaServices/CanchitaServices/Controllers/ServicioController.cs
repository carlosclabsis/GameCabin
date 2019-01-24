using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanchitaServices.Models.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaService.Controllers
{
    [Route("api/[controller]")]
    public class ServicioController : Controller
    {
        private IServicioRepository repositorio;
        public ServicioController(IServicioRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TServicio> Get()
        {
            return repositorio.Items;
        }
        // GET api/<controller>/5
        [HttpGet("{ServicioId}")]

        public TServicio Get(Guid ServicioId)
        {
            return repositorio.Items.Where(p => p.ServId == ServicioId).FirstOrDefault();
        }
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TServicio servicio)
        {
            await repositorio.Save(servicio);
            return Ok(true);
        }
        // PUT api/<controller>/5
        [HttpPut("{ServicioId}")]
        public async Task<IActionResult> Put(Guid ServicioId, [FromBody]TServicio servicio)
        {
            servicio.ServId = ServicioId;
            await repositorio.Save(servicio);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{ServicioId}")]
        public IActionResult Delete(Guid ServicioId)
        {
            repositorio.Delete(ServicioId);
            return Ok(true);
        }
    }
}
