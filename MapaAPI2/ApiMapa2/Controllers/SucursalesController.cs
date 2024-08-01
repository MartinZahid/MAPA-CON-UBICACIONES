using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMapa2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        PointSucursalesContext _context;
        public SucursalesController(PointSucursalesContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> listarSucursales()
        {


            return Ok(await _context.Sucursals
                .Include(s => s.DireccionSucursal)
                .ToListAsync());
        }


        [HttpGet("giro")]

        public async Task<ActionResult> obtenerSucursalesPorGiro([FromQuery] string giro)
        {


            var sucursales = await _context.Sucursals
                .Include(s => s.DireccionSucursal)
                .Include(s => s.IdEmpresaNavigation)
                .Where(s => s.IdEmpresaNavigation.Giro == giro)
                .ToListAsync();
            if (sucursales == null || !sucursales.Any())
            {
                return NotFound("No se encontraron sucursales");
            }

            return Ok(sucursales);
        }

        [HttpGet("estados")]
        public async Task<ActionResult<List<string>>> listarEstados()
        {
            var estados = await _context.Sucursals
                                .Include(s => s.DireccionSucursal)
                                .Select(s => s.DireccionSucursal.Estado)
                                .Distinct()
                                .ToListAsync();
                                
            return Ok(estados);
        }

        [HttpGet("ciudades")]
        public async Task<ActionResult<List<string>>> listarCiudades()
        {
            var ciudades = await _context.Sucursals
                                .Include(s => s.DireccionSucursal)
                                .Select(s => new { s.DireccionSucursal.Ciudad,s.DireccionSucursal.Estado})
                                .Distinct()
                                .ToListAsync();

            return Ok(ciudades);
        }




        [HttpGet("{id:int}")]
        public async Task<ActionResult> obtenerSucursal(int id)
        {
            var sucursal = await _context.Sucursals
                .Include(s => s.DireccionSucursal)
                .FirstOrDefaultAsync(e => e.IdEmpresa == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }


        [HttpGet("ciudad")]
        public async Task<ActionResult<IEnumerable<Sucursal>>> ObtenerSucursalesPorCiudad([FromQuery] string ciudad)
        {


            var sucursales = await _context.Sucursals
                .Include(s => s.DireccionSucursal)
                .Where(s => s.DireccionSucursal.Ciudad == ciudad)
                .ToListAsync();

            if (sucursales == null || !sucursales.Any())
            {
                return NotFound("No se encontraron sucursales en la ciudad especificada.");
            }

            return Ok(sucursales);
        }





        [HttpGet("estado")]
        public async Task<ActionResult> obtenerEmpresasPorEstado([FromQuery] string estado)
        {
            var sucursales = await _context.Sucursals
                .Include(s => s.DireccionSucursal)
                .Where(s => s.DireccionSucursal.Estado == estado)
                .ToListAsync();



            if (sucursales == null || !sucursales.Any())
            {
                return NotFound("No se encontraron sucursales en la ciudad especificada.");
            }

            return Ok(sucursales);
        }

    }
}
