using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MapaAPI.Models;

public partial class Sucursal
{
    public long IdSucursal { get; set; }

    public string? NombreSucursal { get; set; }

    public string? Celular { get; set; }

    public string? PaginaWeb { get; set; }

    public long IdEmpresa { get; set; }

    public virtual DireccionSucursal? DireccionSucursal { get; set; }
    [JsonIgnore]
    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
}
