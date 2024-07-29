namespace ApiMapa2.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string Empresa1 { get; set; } = null!;

    public string Giro { get; set; } = null!;

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
