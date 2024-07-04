using ApiMapa.Context;
using ApiMapa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMapa.Controllers
{
    [ApiController]
    [Route("Sucursal")]
    public class SucursalController : ControllerBase
    {
        public MyDbContext Context { get; }

        public SucursalController(MyDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("ListarEmpresas")]
        public async Task<ActionResult<List<Empresa>>> ListarEmpresas()
        {
            return Ok(await Context.Empresas
                .Include(e => e.Sucursals)
                
                .ToListAsync());
        }
    }
}