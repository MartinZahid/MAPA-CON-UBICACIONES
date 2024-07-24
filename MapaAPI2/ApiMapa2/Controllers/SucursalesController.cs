using ApiMapa2.Models;
using Microsoft.AspNetCore.Http;
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
            var sucursales = await _context.Sucursals.ToListAsync();
            return Ok(sucursales);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> obtenerSucursal(int id)
        {
            var sucursal = await _context.Sucursals.FirstOrDefaultAsync(e => e.IdEmpresa == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }


        //[HttpGet("por-ciudad")]
        //public async Task<ActionResult<IEnumerable<Sucursal>>> ObtenerSucursalesPorCiudad([FromQuery] string ciudad)
        //{


        //    var sucursales = await _context.Sucursals
        //        .Include(s => s.DireccionSucursal)
        //        .Where(s => s.DireccionSucursal.Ciudad == ciudad)
        //        .ToListAsync();

        //    if (sucursales == null || !sucursales.Any())
        //    {
        //        return NotFound("No se encontraron sucursales en la ciudad especificada.");
        //    }

        //    return Ok(sucursales);
        //}





        //[HttpGet("por-estado")]
        //public async Task<ActionResult> obtenerEmpresasPorEstado([FromQuery] string ciudad)
        //{
        //    var empresas = await _context.Empresas.Where(e => e.Giro == giro).ToListAsync();
        //    if (!empresas.Any())
        //    {
        //        return NotFound();
        //    }

        //    return Ok(empresas);
        //}

    }
}
