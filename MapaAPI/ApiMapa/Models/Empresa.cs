using System;
using System.Collections.Generic;

namespace ApiMapa.Models;

public partial class Empresa
{
    public long IdEmpresa { get; set; }

    public string Nombre { get; set; } = null!;

    public ulong Activo { get; set; }

    public string? Giro { get; set; }

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
