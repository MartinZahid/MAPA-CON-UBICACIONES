using ApiMapa.Context;
using ApiMapa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMapa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {

        public MyDbContext Context { get; }

        public SucursalesController(MyDbContext context)
        {
            Context = context;
        }



        // GET: api/<SucursalesController>
        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> ListarSucursales()
        {
            return Ok(await Context.Sucursals.ToListAsync());
        }

        // GET api/<SucursalesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerSucursal(int id)
        {
            var sucursal = await Context.Sucursals.FirstOrDefaultAsync(e => e.IdSucursal == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }


    }
}
