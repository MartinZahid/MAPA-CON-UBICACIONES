using System;
using System.Collections.Generic;

namespace MapaAPI.Models;

public partial class Sucursal
{
    public long IdSucursal { get; set; }

    public string? NombreSucursal { get; set; }

    public string? Celular { get; set; }

    public string? PaginaWeb { get; set; }

    public long? IdEmpresa { get; set; }

    public virtual ICollection<DireccionSucursal> DireccionSucursals { get; set; } = new List<DireccionSucursal>();

    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
