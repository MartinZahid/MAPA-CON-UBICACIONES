using Microsoft.EntityFrameworkCore;

namespace ApiMapa2.Models;

public partial class PointSucursalesContext : DbContext
{
    public PointSucursalesContext()
    {
    }

    public PointSucursalesContext(DbContextOptions<PointSucursalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DireccionSucursal> DireccionSucursals { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=softwareforcs-db.cyg0a1g9kjty.us-west-1.rds.amazonaws.com;database=PointSucursales;user=maguilar;password=esuXCC703_%@", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<DireccionSucursal>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PRIMARY");

            entity.ToTable("direccionSucursal");

            entity.HasIndex(e => e.IdSucursal, "idSucursal").IsUnique();

            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.CP)
                .HasMaxLength(32)
                .HasColumnName("cP");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .HasColumnName("ciudad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasMaxLength(64)
                .HasColumnName("estado");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 7)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(10, 7)
                .HasColumnName("longitud");

            entity.HasOne(d => d.IdSucursalNavigation).WithOne(p => p.DireccionSucursal)
                .HasForeignKey<DireccionSucursal>(d => d.IdSucursal)
                .HasConstraintName("direccionSucursal_ibfk_1");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PRIMARY");

            entity.ToTable("empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Empresa1)
                .HasMaxLength(100)
                .HasColumnName("empresa");
            entity.Property(e => e.Giro)
                .HasMaxLength(100)
                .HasColumnName("giro");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PRIMARY");

            entity.ToTable("sucursal");

            entity.HasIndex(e => e.IdEmpresa, "idEmpresa");

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Sucursal1)
                .HasMaxLength(100)
                .HasColumnName("sucursal");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("sucursal_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
