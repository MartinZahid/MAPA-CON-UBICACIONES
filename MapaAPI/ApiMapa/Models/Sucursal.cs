using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiMapa.Models;

public partial class Sucursal
{
    public long IdSucursal { get; set; }

    public string NombreSucursal { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string PaginaWeb { get; set; } = null!;

    public long IdEmpresa { get; set; }

    public virtual ICollection<DireccionSucursal> DireccionSucursals { get; set; } = new List<DireccionSucursal>();
    [JsonIgnore]
    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
}
