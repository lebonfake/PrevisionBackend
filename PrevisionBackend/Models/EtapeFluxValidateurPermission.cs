using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
    public class EtapeFluxValidateurPermission
    {
        // ATTENTION : Suppression des attributs [Key] sur les propriétés individuelles.
        // La clé primaire composite est maintenant définie UNIQUEMENT dans OnModelCreating.
        [Column(Order = 1)]
        public int EtapeFluxId { get; set; }
        [ForeignKey("EtapeFluxId")]
        public EtapeFlux EtapeFlux { get; set; }

        [Column(Order = 2)]
        public int ValidateurId { get; set; }
        [ForeignKey("ValidateurId")]
        public Validateur Validateur { get; set; }

        [Column(Order = 3)]
        public int PermissionPrevId { get; set; }
        [ForeignKey("PermissionPrevId")]
        public PermissionPrev PermissionPrev { get; set; }

        // Vous pouvez ajouter des propriétés supplémentaires à cette table de jonction
        // Par exemple: Date d'assignation, statut spécifique à cette association, etc.
        public DateTime DateAssigned { get; set; } = DateTime.UtcNow;
    }
}