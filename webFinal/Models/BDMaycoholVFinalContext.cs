using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace webFinal.Models
{
    public partial class BDMaycoholVFinalContext : DbContext
    {
        public BDMaycoholVFinalContext()
        {
        }

        public BDMaycoholVFinalContext(DbContextOptions<BDMaycoholVFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SJLTNMT;Initial Catalog=BDMaycoholVFinal;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK__Categori__70E82E2815993EB2");

                entity.Property(e => e.Idcategoria)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("IDCategoria");

                entity.Property(e => e.NombreCat)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Cat");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PK__Cliente__C035B8DC95DC0E09");

                entity.ToTable("Cliente");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(180)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.ImagenC).IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.HasKey(e => e.Iddetalle)
                    .HasName("PK__DetalleV__32EB9E47F6B86AC8");

                entity.Property(e => e.Iddetalle)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("IDDetalle");

                entity.Property(e => e.Idproducto)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("IDProducto");

                entity.Property(e => e.Idventa)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("IDVenta");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("FK__DetalleVe__IDPro__34C8D9D1");

                entity.HasOne(d => d.IdventaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.Idventa)
                    .HasConstraintName("FK__DetalleVe__IDVen__33D4B598");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Idempleado)
                    .HasName("PK__Empleado__50621DCDAE7184D5");

                entity.ToTable("Empleado");

                entity.Property(e => e.Idempleado)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("IDEmpleado");

                entity.Property(e => e.ApellidosE)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellidos_E");

                entity.Property(e => e.NombresE)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombres_E");

                entity.Property(e => e.Sueldo).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK__Producto__ABDAF2B42735D785");

                entity.ToTable("Producto");

                entity.Property(e => e.Idproducto)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("IDProducto");

                entity.Property(e => e.Idcategoria)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("IDCategoria");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.NombreProd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Prod");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("RUC");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK__Producto__IDCate__30F848ED");

                entity.HasOne(d => d.RucNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Ruc)
                    .HasConstraintName("FK__Producto__RUC__300424B4");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Ruc)
                    .HasName("PK__Proveedo__CAF3326A2035362F");

                entity.ToTable("Proveedor");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("RUC");

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(180)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Empresa");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("PK__Venta__27134B82215ADF86");

                entity.Property(e => e.Idventa)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("IDVenta");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Idempleado)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("IDEmpleado");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Dni)
                    .HasConstraintName("FK__Venta__DNI__2C3393D0");

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idempleado)
                    .HasConstraintName("FK__Venta__IDEmplead__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
