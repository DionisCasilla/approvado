using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Approvado.Models;

public partial class DbA46041ApprovadoContext : DbContext
{
    public DbA46041ApprovadoContext()
    {
    }

    public DbA46041ApprovadoContext(DbContextOptions<DbA46041ApprovadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empresa> Empresas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5112.site4now.net;Initial Catalog=db_a46041_approvado;User Id=db_a46041_approvado_admin;Password=casilla!2");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Empresa1);

            entity.ToTable("Empresa");

            entity.Property(e => e.Empresa1)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Empresa");
            entity.Property(e => e.CorreoPrincipal)
                .HasMaxLength(200)
                .HasColumnName("Correo_Principal");
            entity.Property(e => e.Descripcion).HasColumnType("ntext");
            entity.Property(e => e.Direccion).HasMaxLength(400);
            entity.Property(e => e.Estatus).HasDefaultValue(1);
            entity.Property(e => e.Nombre)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryColor)
                .HasMaxLength(50)
                .HasColumnName("Primary_Color");
            entity.Property(e => e.RncCedula)
                .HasMaxLength(50)
                .HasColumnName("RNC_CEDULA");
            entity.Property(e => e.SecondColor)
                .HasMaxLength(50)
                .HasColumnName("Second_Color");
            entity.Property(e => e.Telefono1).HasMaxLength(50);
            entity.Property(e => e.Telefono2).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
