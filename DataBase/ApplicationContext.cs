using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<TipoPrimario> TipoPrimario { get; set; }
        public DbSet<TipoSecundario> TipoSecundario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Pokemon>().ToTable("Pokemon");
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<TipoPrimario>().ToTable("TipoPrimario");
            modelBuilder.Entity<TipoSecundario>().ToTable("TipoSecundario");
            #endregion

            #region primary keys
            modelBuilder.Entity<Pokemon>().HasKey(p=> p.idPokemon);
            modelBuilder.Entity<Region>().HasKey(p => p.idRegion);
            modelBuilder.Entity<TipoPrimario>().HasKey(p => p.idTipoPrimario);
            modelBuilder.Entity<TipoSecundario>().HasKey(p => p.idTipoSecundario);
            #endregion

            #region Relationships
            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(c => c.Pokemons)
                .WithOne(p => p.Region)
                .HasForeignKey(p=> p.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TipoPrimario>()
                .HasMany<Pokemon>(c => c.Pokemons)
                .WithOne(p => p.TipoPrimario)
                .HasForeignKey(p => p.TipoPrimarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TipoSecundario>()
                .HasMany<Pokemon>(c => c.Pokemons)
                .WithOne(p => p.TipoSecundario)
                .HasForeignKey(p => p.TipoSecundarioId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Property configurations
            #region Pokemon
            modelBuilder.Entity<Pokemon>().Property(p => p.imgPokemon).IsRequired();
            modelBuilder.Entity<Pokemon>().Property(p => p.nombre).IsRequired();
            #endregion
            #region Region
            modelBuilder.Entity<Region>().Property(p => p.Nombre).IsRequired();
            #endregion
            #region TipoPrimario
            modelBuilder.Entity<TipoPrimario>().Property(p => p.Nombre).IsRequired();
            #endregion
            #region TipoSecundario
            modelBuilder.Entity<TipoSecundario>().Property(p => p.Nombre).IsRequired();
            #endregion
            #endregion
        }

    }
}
