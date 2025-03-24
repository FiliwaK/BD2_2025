﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace wfa_scolaireDepart.Models;

public partial class k2fl_bdContext : DbContext
{
    public k2fl_bdContext()
    {
    }

    public k2fl_bdContext(DbContextOptions<k2fl_bdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCour> TblCours { get; set; }

    public virtual DbSet<TblEtudiant> TblEtudiants { get; set; }

    public virtual DbSet<TblInscription> TblInscriptions { get; set; }

    public virtual DbSet<TblOffreCour> TblOffreCours { get; set; }

    public virtual DbSet<TblSession> TblSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=bd-tinfo;Initial Catalog=k2fl_bd;Integrated Security=True;Encrypt=False").LogTo(Console.Write, LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCour>(entity =>
        {
            entity.HasKey(e => e.NoCours).HasName("PK__tbl_cour__1297542F362E6D3D");

            entity.Property(e => e.NoCours).IsFixedLength();
            entity.Property(e => e.Pond)
                .HasDefaultValue("1-1-1")
                .IsFixedLength();

            entity.HasMany(d => d.NoCoursDeBases).WithMany(p => p.NoCoursPrealables)
                .UsingEntity<Dictionary<string, object>>(
                    "TblPrealable",
                    r => r.HasOne<TblCour>().WithMany()
                        .HasForeignKey("NoCoursDeBase")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prealableDeBase_FK"),
                    l => l.HasOne<TblCour>().WithMany()
                        .HasForeignKey("NoCoursPrealable")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prealable_FK"),
                    j =>
                    {
                        j.HasKey("NoCoursDeBase", "NoCoursPrealable").HasName("PK_prealable");
                        j.ToTable("tbl_prealable");
                        j.IndexerProperty<string>("NoCoursDeBase")
                            .HasMaxLength(8)
                            .IsFixedLength()
                            .HasColumnName("no_coursDeBase");
                        j.IndexerProperty<string>("NoCoursPrealable")
                            .HasMaxLength(8)
                            .IsFixedLength()
                            .HasColumnName("no_coursPrealable");
                    });

            entity.HasMany(d => d.NoCoursPrealables).WithMany(p => p.NoCoursDeBases)
                .UsingEntity<Dictionary<string, object>>(
                    "TblPrealable",
                    r => r.HasOne<TblCour>().WithMany()
                        .HasForeignKey("NoCoursPrealable")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prealable_FK"),
                    l => l.HasOne<TblCour>().WithMany()
                        .HasForeignKey("NoCoursDeBase")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prealableDeBase_FK"),
                    j =>
                    {
                        j.HasKey("NoCoursDeBase", "NoCoursPrealable").HasName("PK_prealable");
                        j.ToTable("tbl_prealable");
                        j.IndexerProperty<string>("NoCoursDeBase")
                            .HasMaxLength(8)
                            .IsFixedLength()
                            .HasColumnName("no_coursDeBase");
                        j.IndexerProperty<string>("NoCoursPrealable")
                            .HasMaxLength(8)
                            .IsFixedLength()
                            .HasColumnName("no_coursPrealable");
                    });
        });

        modelBuilder.Entity<TblEtudiant>(entity =>
        {
            entity.HasKey(e => e.NoDa).HasName("PK__tbl_etud__E2D4DBFA894B87B1");

            entity.Property(e => e.NoDa).IsFixedLength();
        });

        modelBuilder.Entity<TblInscription>(entity =>
        {
            entity.HasKey(e => new { e.NoDa, e.NoOffreCours }).HasName("PK_inscription");

            entity.Property(e => e.NoDa).IsFixedLength();

            entity.HasOne(d => d.NoDaNavigation).WithMany(p => p.TblInscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_inscription_da");

            entity.HasOne(d => d.NoOffreCoursNavigation).WithMany(p => p.TblInscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_inscription_offreCours");
        });

        modelBuilder.Entity<TblOffreCour>(entity =>
        {
            entity.HasKey(e => e.NoOffreCours).HasName("PK__tbl_offr__42BFB71403130DAE");

            entity.Property(e => e.NoCours).IsFixedLength();
            entity.Property(e => e.NoSession).IsFixedLength();

            entity.HasOne(d => d.NoCoursNavigation).WithMany(p => p.TblOffreCours).HasConstraintName("FK__tbl_offre__no_co__3E52440B");

            entity.HasOne(d => d.NoSessionNavigation).WithMany(p => p.TblOffreCours).HasConstraintName("FK__tbl_offre__no_se__3D5E1FD2");
        });

        modelBuilder.Entity<TblSession>(entity =>
        {
            entity.HasKey(e => e.NoSession).HasName("PK__tbl_sess__6DBB4FB9C92E0C2E");

            entity.Property(e => e.NoSession).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}