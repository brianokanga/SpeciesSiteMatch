using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpeciesSiteMatch.Data.Models;

namespace SpeciesSiteMatch.Data.Data
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
    }
}
