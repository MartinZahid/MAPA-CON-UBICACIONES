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
   
        public async Task<ActionResult> ObtenerEmpresa(long idEmpresa)
        {
            var empresa = await Context.Empresas

           .FirstOrDefaultAsync(e => e.IdEmpresa == idEmpresa);
            if (empresa == null)
            {
                return NotFound(); // Retorna HTTP 404 si no se encuentra la empresa
            }

            return Ok(empresa); // Retorna la empresa encontrada
        }
    }
}