﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoF2.Models;

public partial class BibliotecaMarcos3Context : DbContext
{
    public BibliotecaMarcos3Context()
    {
    }

    public BibliotecaMarcos3Context(DbContextOptions<BibliotecaMarcos3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
 //       => optionsBuilder.UseSqlServer("Data Source=JHON\\SQLEXPRESS;Initial Catalog=Biblioteca_Marcos3;User ID=sa;Password=jairo4556;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__LIBRO__3E0B49ADE134048A");

            entity.ToTable("LIBRO");

            entity.Property(e => e.IdLibro).ValueGeneratedNever();
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Editorial)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GeneroLiterario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Genero_Literario");
            entity.Property(e => e.NombrePortada)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__PRESTAMO__6FF194C0E8403D7C");

            entity.ToTable("PRESTAMO");

            entity.Property(e => e.IdPrestamo).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaConfirmacionDevolucion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__PRESTAMO__IdLibr__3F466844");

            entity.HasOne(d => d.IdentificacionNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Identificacion)
                .HasConstraintName("FK__PRESTAMO__Identi__3E52440B");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CBF792BD2");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Identificacion).HasName("PK__Usuario__D6F931E4FC8992F7");

            entity.ToTable("Usuario");

            entity.Property(e => e.Identificacion).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__IdRol__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
