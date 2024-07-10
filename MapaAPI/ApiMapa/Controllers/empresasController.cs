using ApiMapa.Context;
using ApiMapa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMapa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empresasController : ControllerBase
    {
        public MyDbContext Context { get; }

        public empresasController(MyDbContext context)
        {
            Context = context;
        }
        // GET: api/<empresasController>
        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> ListarEmpresas()
        {

            return Ok(await Context.Empresas
                .ToListAsync());
        }

        // GET api/<empresasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerEmpresa(int id)
        {
            var empresa = await Context.Empresas

           .FirstOrDefaultAsync(e => e.IdEmpresa == id);
            if (empresa == null)
            {
                return NotFound(); // Retorna HTTP 404 si no se encuentra la empresa
            }

            return Ok(empresa); // Retorna la empresa encontrada
        }

        // POST api/<empresasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<empresasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<empresasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
