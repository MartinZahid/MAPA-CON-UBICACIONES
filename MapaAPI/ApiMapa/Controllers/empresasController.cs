using ApiMapa.Context;
using ApiMapa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMapa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        public MyDbContext Context { get; }

        public EmpresasController(MyDbContext context)
        {
            Context = context;
        }

        // GET: api/empresas
        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> ListarEmpresas()
        {
            return Ok(await Context.Empresas.ToListAsync());
        }

        // GET: api/empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerEmpresa(int id)
        {
            var empresa = await Context.Empresas.FirstOrDefaultAsync(e => e.IdEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        // GET: api/empresas/{giro}
        [HttpGet("{giro}")]
        public async Task<ActionResult> ObtenerEmpresaGiro(string giro)
        {
            var empresas = await Context.Empresas.Where(e => e.Giro == giro).ToListAsync();
            if (!empresas.Any())
            {
                return NotFound();
            }

            return Ok(empresas);
        }
    }
}
