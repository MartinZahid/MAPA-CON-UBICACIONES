using System;
using System.Collections.Generic;

namespace ApiMapa.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Sucursal1 { get; set; } = null!;

    public int? IdEmpresa { get; set; }

    public virtual DireccionSucursal? DireccionSucursal { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
