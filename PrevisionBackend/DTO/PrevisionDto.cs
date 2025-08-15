using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrevisionBackend.DTO
{
    
    public enum TypePrevisionDto
    {
        Journaliere,
        Hebdo,
        SixWeeks
    }

    public enum StatutPrevisionDto
    {
        Valide,
        EnAttente,
        Annule
    }

    // DTO for creating a LignePrevision
    public class LignePrevisionCreateDto
    {
        [Required]
        public decimal Valeur { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }

    // DTO for creating PrevisionDetails
    public class PrevisionDetailsCreateDto
    {
        // No IdPrevision needed here, as it will be set by the parent Prevision during mapping

        [Required]
        public int SecteurId { get; set; } // Assuming you link to an existing Secteur by ID

        [Required]
        public int CycleId { get; set; } // Assuming you link to an existing Cycle by ID

        [Required]
        public int NumCulture { get; set; }

        [Required]
        [StringLength(100)] // Adjust max length as per your model
        public string Parcelle { get; set; }

        public List<LignePrevisionCreateDto> LignesPrevision { get; set; } = new List<LignePrevisionCreateDto>();
    }

    // Main DTO for creating a Prevision
    public class PrevisionCreateDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TypePrevisionDto Type { get; set; } // Use DTO enum

        [Required]
        [StringLength(50)] // Match Ferme.CodFerm length
        public string FermeId { get; set; } // ID of the existing Ferme

        [Required]
        public int CreeParUserId { get; set; } // ID of the User who created it (renamed to avoid conflict with 'CreePar' property name if it's a User object)

        // StatutPrevision will likely be 'EnAttente' or 'Valide' by default upon creation.
        // You might want to omit this from the DTO if it's always set by the backend logic,
        // or provide it for flexibility.
        public StatutPrevisionDto Statut { get; set; } = StatutPrevisionDto.EnAttente; // Default value example

        // Collection of PrevisionDetails for this Prevision
        public List<PrevisionDetailsCreateDto> Details { get; set; } = new List<PrevisionDetailsCreateDto>();

        [Required]
        public int VersionId { get; set; } // ID of the existing Version

        [Required]
        public int FluxId { get; set; } // ID of the existing Flux
    }
}
