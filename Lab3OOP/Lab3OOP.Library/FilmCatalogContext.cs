using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab3OOP.Library;

public partial class FilmCatalogContext : DbContext
{
    public FilmCatalogContext()
    {
    }

    public FilmCatalogContext(DbContextOptions<FilmCatalogContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Studio> Studios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlite("Data Source=H:\\\\FilmCatalog.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.ToTable("Director");

            entity.HasIndex(e => e.Id, "IX_Director_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("Film");

            entity.HasIndex(e => e.Id, "IX_Film_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.DirectorNavigation).WithMany(p => p.Films)
                .HasForeignKey(d => d.Director)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.Films)
                .HasForeignKey(d => d.Genre)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.StudioNavigation).WithMany(p => p.Films)
                .HasForeignKey(d => d.Studio)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.HasIndex(e => e.Id, "IX_Genre_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Studio>(entity =>
        {
            entity.ToTable("Studio");

            entity.HasIndex(e => e.Id, "IX_Studio_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
