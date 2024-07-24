using ApiMapa2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMapa2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly PointSucursalesContext _context;
        public EmpresasController(PointSucursalesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> listarEmpresas()
        {
            var empresas = await _context.Empresas.ToListAsync();
            return Ok(empresas);
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult> obtenerEmpresa(int id)
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.IdEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }


        // GET: api/empresas?giro={giro}
        [HttpGet("por-giro")]
        public async Task<ActionResult> ObtenerEmpresasPorGiro([FromQuery] string giro)
        {
            var empresas = await _context.Empresas.Where(e => e.Giro == giro).ToListAsync();
            if (!empresas.Any())
            {
                return NotFound();
            }

            return Ok(empresas);
        }



    }
}
