using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaABC.Models;

public partial class DbpruebaTecnicaAngelContext : DbContext
{
    public DbpruebaTecnicaAngelContext()
    {
    }

    public DbpruebaTecnicaAngelContext(DbContextOptions<DbpruebaTecnicaAngelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TiposProducto> TiposProductos { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83F5FBB0A6C");

            entity.ToTable("Producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Existencia).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FechaEliminado).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasColumnName("status");
            entity.Property(e => e.TipoProductoId).HasColumnName("TipoProducto_Id");
          /*
            entity.HasOne(d => d.TipoProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.TipoProductoId)
                .HasConstraintName("FK__Producto__TipoPr__6EF57B66");
          */
        });

        modelBuilder.Entity<TiposProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TiposPro__3214EC07CADEDA11");

            entity.Property(e => e.DescripcionTipoProducto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcionTipoProducto");
            entity.Property(e => e.FechaEliminado).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreTipoProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoProducto");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
