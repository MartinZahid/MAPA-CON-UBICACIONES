using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapaAPI.Controllers
{

    [ApiController]
    [Route("Sucursal")]
    public class SucursalController : ControllerBase
    {
        public PointSucursalesContext Context { get; }
        public SucursalController(PointSucursalesContext Context) {
            this.Context = Context;
        }



        [HttpGet]
        [Route("ListarEmpresas")]
        public async Task<ActionResult<List<Empresa>>> ListarEmpresas() {

            return Ok(await Context.Empresas
                .Include(p => p.Sucursal)
                .ThenInclude(p => p.DireccionSucursal)
                .ToListAsync()); 
        }
    }
}
