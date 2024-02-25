using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace app.Models;

public partial class BeerDbContext : DbContext
{
    public BeerDbContext()
    {
    }

    public BeerDbContext(DbContextOptions<BeerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=beer_db; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.BeerId).HasName("PK__beer__B5D4D62EF1268868");

            entity.ToTable("beer");

            entity.Property(e => e.BeerId).HasColumnName("beer_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Brand).WithMany(p => p.Beers)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__beer__brand_id__398D8EEE");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brand__5E5A8E270A7575F3");

            entity.ToTable("brand");

            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
