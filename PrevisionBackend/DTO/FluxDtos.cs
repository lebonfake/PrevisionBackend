using System.ComponentModel.DataAnnotations;

namespace PrevisionBackend.DTO
{
    public class FluxCreateDto
    {

        public string Nom { get; set; } = string.Empty;
        public List<EtapeFluxCreateDto> EtapeFluxs { get; set; }


    }

    public class EtapeFluxCreateDto
    {
        public int Ordre { get; set; }
        public string Nom { get; set; }
        public List<EtapeFluxValidateurPermissionLinkDto> EtapeFluxValidateurPermissionLinks { get; set; }

    }

    public class EtapeFluxValidateurPermissionLinkDto
    {
        [Required]
        public int ValidateurId { get; set; } // L'ID d'un Validateur existant

        [Required]
        public int PermissionPrevId { get; set; } // L'ID d'une PermissionPrev existante

        // Si la table de jonction EtapeFluxValidateurPermission a d'autres propriétés
        // comme 'DateAssigned', vous pouvez l'inclure ici.
        // public DateTime DateAssigned { get; set; }
    }
    // Nouveau DTO pour la lecture/réponse d'un Flux
    public class FluxReadDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int NombreEtapes { get; set; } // Compter les étapes pour la réponse
        // Vous pourriez inclure d'autres détails sur les étapes de flux ici si nécessaire
        // public List<EtapeFluxReadDto> EtapesFlux { get; set; }
        public List<FermeReadDto> Fermes { get; set; }
    }

}
