using System.Text.Json.Serialization;

namespace ApiMapa2.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Sucursal1 { get; set; } = null!;

    public int? IdEmpresa { get; set; }

    public virtual DireccionSucursal? DireccionSucursal { get; set; }
    [JsonIgnore]
    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
