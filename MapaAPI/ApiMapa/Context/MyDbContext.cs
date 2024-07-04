using System;
using System.Collections.Generic;
using ApiMapa.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ApiMapa.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DireccionSucursal> DireccionSucursals { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=softwareforcs-db.cyg0a1g9kjty.us-west-1.rds.amazonaws.com;port=3306;database=PointSucursales;user=maguilar;password=esuXCC703_%@", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<DireccionSucursal>(entity =>
        {
            entity.HasKey(e => e.IdDireccionSucursal).HasName("PRIMARY");

            entity.ToTable("direccionSucursal");

            entity.HasIndex(e => e.IdSucursal, "idSucursal");

            entity.Property(e => e.IdDireccionSucursal).HasColumnName("idDireccionSucursal");
            entity.Property(e => e.Calle)
                .HasMaxLength(64)
                .HasColumnName("calle");
            entity.Property(e => e.Cp)
                .HasMaxLength(16)
                .HasColumnName("cp");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 7)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(10, 7)
                .HasColumnName("longitud");
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(16)
                .HasColumnName("numeroInterior");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.DireccionSucursals)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("direccionSucursal_ibfk_1");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PRIMARY");

            entity.ToTable("empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Activo)
                .HasColumnType("bit(1)")
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PRIMARY");

            entity.ToTable("sucursal");

            entity.HasIndex(e => e.IdEmpresa, "idEmpresa");

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Celular)
                .HasMaxLength(64)
                .HasColumnName("celular");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.NombreSucursal)
                .HasMaxLength(64)
                .HasColumnName("nombreSucursal");
            entity.Property(e => e.PaginaWeb)
                .HasMaxLength(64)
                .HasColumnName("paginaWeb");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursal_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
