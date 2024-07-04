using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiMapa.Models;

public partial class DireccionSucursal
{
    public long IdDireccionSucursal { get; set; }

    public string Calle { get; set; } = null!;

    public string Cp { get; set; } = null!;

    public string NumeroInterior { get; set; } = null!;

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public long IdSucursal { get; set; }
    [JsonIgnore]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
