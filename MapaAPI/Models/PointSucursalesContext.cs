using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MapaAPI.Models;

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
        => optionsBuilder.UseSqlServer("Server=point-practicas.c5muoyw2g1g6.us-west-1.rds.amazonaws.com;Database=PointSucursales;User Id=maguilar;Password=esuXCC703_%@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DireccionSucursal>(entity =>
        {
            entity.HasKey(e => e.IdDireccionSucursal).HasName("PK__direccio__F4EB78B0673C7F6F");

            entity.ToTable("direccionSucursal");

            entity.HasIndex(e => e.IdSucursal, "UQ__direccio__F707694D2B2D3ACF").IsUnique();

            entity.Property(e => e.IdDireccionSucursal).HasColumnName("idDireccionSucursal");
            entity.Property(e => e.Calle)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Cp)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("cp");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Latitud)
                .HasColumnType("decimal(10, 7)")
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasColumnType("decimal(10, 7)")
                .HasColumnName("longitud");
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("numeroInterior");

            entity.HasOne(d => d.IdSucursalNavigation).WithOne(p => p.DireccionSucursal)
                .HasForeignKey<DireccionSucursal>(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__direccion__idSuc__17F790F9");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__empresa__75D2CED41776D69A");

            entity.ToTable("empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__sucursal__F707694C70B17ABD");

            entity.ToTable("sucursal");

            entity.HasIndex(e => e.IdEmpresa, "UQ__sucursal__75D2CED58D68186D").IsUnique();

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Celular)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.NombreSucursal)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("nombreSucursal");
            entity.Property(e => e.PaginaWeb)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("paginaWeb");

            entity.HasOne(d => d.IdEmpresaNavigation).WithOne(p => p.Sucursal)
                .HasForeignKey<Sucursal>(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sucursal__idEmpr__14270015");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
