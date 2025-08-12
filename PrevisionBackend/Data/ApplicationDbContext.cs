using Microsoft.EntityFrameworkCore;
using PrevisionBackend.Models;
using System.Collections.Generic; // Only if you use ICollection

namespace PrevisionBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Declare DbSets for your models
        public DbSet<Region> Regions { get; set; }
        public DbSet<Producteur> Producteurs { get; set; }
        public DbSet<Ferme> Fermes { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Variete> Varietes { get; set; }
        public DbSet<VarieteChamp> VarieteChamps { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<Secteur> Secteurs { get; set; }
        public DbSet<Assolement> Assolements { get; set; }

        // prevision 
        public DbSet<Prevision> PrevisionFermes { get; set; }
        public DbSet<PrevisionDetails> PrevisionDetails { get; set; }
        public DbSet<LignePrevision> LignePrevisions { get; set; }

        //flux
        public DbSet<Flux> Flux { get; set; }
        public DbSet<EtapeFlux> EtapeFlux { get; set; }
        public DbSet<EtapePrev> EtapePrev { get; set; }

        public DbSet<Validateur> Validateurs { get; set; }
        public DbSet<EtapeFluxValidateurPermission> EtapeFluxValidateurPermissions { get; set; }
        public DbSet<PermissionPrev> PermissionPrevisions { get; set; }

        // Authentication and authorization models
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ProfilePermission> ProfilePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de la clé primaire composite pour ProfilePermission
            modelBuilder.Entity<ProfilePermission>()
                .HasKey(pp => new { pp.ProfileID, pp.PermissionID });

            // Configuration des relations pour ProfilePermission (Many-to-Many explicite)
            modelBuilder.Entity<ProfilePermission>()
                .HasOne(pp => pp.Profile)
                .WithMany(p => p.ProfilePermissions)
                .HasForeignKey(pp => pp.ProfileID);

            modelBuilder.Entity<ProfilePermission>()
                .HasOne(pp => pp.Permission)
                .WithMany(p => p.ProfilePermissions)
                .HasForeignKey(pp => pp.PermissionID);

            // Configuration de la contrainte UNIQUE pour Assolement
            // Sur les colonnes (ferme, secteur, cycle, parcelle, num_culture, variete_champ)
            modelBuilder.Entity<Assolement>()
                .HasIndex(a => new {
                    a.FermeCod,
                    a.SecteurId,
                    a.CycleId,
                    a.Parcelle,
                    a.NumCulture,
                    a.VarieteChampId
                })
                .IsUnique();

            modelBuilder.Entity<EtapePrev>()
                // Relation with EtapeFlux
                .HasOne(e => e.EtapeFlux)
                .WithMany()                        // assuming EtapeFlux does NOT have a collection of EtapePrev
                .HasForeignKey("EtapeFluxId")      // or e => e.EtapeFluxId if FK exists
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete

            modelBuilder.Entity<Assolement>()
    .HasOne(a => a.Secteur)
    .WithMany(s => s.Assolements)
    .HasForeignKey(a => a.SecteurId)
    .OnDelete(DeleteBehavior.Restrict); // empêche cascade delete qui cause problème

            modelBuilder.Entity<Secteur>()
                .HasOne(s => s.Ferme)
                .WithMany() // ou avec collection si elle existe
                .HasForeignKey(s => s.CodFerm)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assolement>()
                .HasOne(a => a.Ferme)
                .WithMany() // si pas de collection dans Ferme
                .HasForeignKey(a => a.FermeCod)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assolement>()
                .HasOne(a => a.Secteur)
                .WithMany(s => s.Assolements)
                .HasForeignKey(a => a.SecteurId)
                .OnDelete(DeleteBehavior.Restrict); // empêche cascade delete qui cause problème

                modelBuilder.Entity<Secteur>()
                .HasOne(s => s.Ferme)
                .WithMany() // ou avec collection si elle existe
                .HasForeignKey(s => s.CodFerm)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assolement>()
                .HasOne(a => a.Ferme)
                .WithMany() // si pas de collection dans Ferme
                .HasForeignKey(a => a.FermeCod)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<EtapeFluxValidateurPermission>()
    .HasKey(efvp => new { efvp.EtapeFluxId, efvp.ValidateurId, efvp.PermissionPrevId });

            modelBuilder.Entity<LignePrevision>()
           .Property(lp => lp.Valeur)
           .HasPrecision(18, 2); // Par exemple: 18 chiffres au total, 2 après la virgule.
                                 // Ajustez ces valeurs (18, 2) selon vos besoins métier réels.

            // Si 'Module_Permissions' dans 'Permission' ne se mappe pas correctement par convention
            // et que vous avez des problèmes, vous pourriez avoir besoin de le spécifier explicitement.
            // Par exemple:
            // modelBuilder.Entity<Permission>()
            //     .HasOne(p => p.Module)
            //     .WithMany(m => m.Permissions)
            //     .HasForeignKey(p => p.Module_Permissions); // Assurez-vous que le nom de la colonne FK est correct
        }
    }
}
