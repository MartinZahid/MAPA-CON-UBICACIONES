using System;
using System.Collections.Generic;

namespace MapaAPI.Models;

public partial class Empresa
{
    public long IdEmpresa { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual Sucursal? Sucursal { get; set; }
}
