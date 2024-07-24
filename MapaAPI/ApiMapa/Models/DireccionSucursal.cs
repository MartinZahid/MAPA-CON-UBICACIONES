﻿using System;
using System.Collections.Generic;

namespace ApiMapa.Models;

public partial class DireccionSucursal
{
    public int IdDireccion { get; set; }

    public string? Direccion { get; set; }

    public string CP { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public int? IdSucursal { get; set; }

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
