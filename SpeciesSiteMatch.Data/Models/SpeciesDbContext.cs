using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpeciesSiteMatch.Data.Models
{
    public partial class SpeciesDbContext : DbContext
    {
        public SpeciesDbContext()
        {
        }

        public SpeciesDbContext(DbContextOptions<SpeciesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<SpecieDetail> SpecieDetails { get; set; }
        public virtual DbSet<Specie> Species { get; set; }
        public virtual DbSet<SubCounty> SubCounties { get; set; }
        //public virtual DbSet<PlantRequest> PlantRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SpeciesDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<County>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Idx_County_Name");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.SubCounty)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.SubCountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations_SubCounties");
            });

            
            modelBuilder.Entity<SpecieDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SpecieDetails)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecieDetails_Locations");

                entity.HasOne(d => d.Specie)
                    .WithMany(p => p.SpecieDetails)
                    .HasForeignKey(d => d.SpecieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecieDetails_Species");
            });

            modelBuilder.Entity<Specie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SubCounty>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.CountyId })
                    .HasName("Idx_SubCounties_Name");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.County)
                    .WithMany(p => p.SubCounties)
                    .HasForeignKey(d => d.CountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCounties_Counties");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
