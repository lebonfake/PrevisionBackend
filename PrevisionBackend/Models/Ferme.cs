// Modèle pour la table 'Ferme'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
public class Ferme
{
    [Key]
    [Column("cod_ferm")]
    [StringLength(50)]
    public string CodFerm { get; set; }

    [Column("nom_ferm")]
    [StringLength(50)]
    public string NomFerm { get; set; }

    [Column("superficie")]
    public float Superficie { get; set; }

    // Clé étrangère pour 'Region'
    [Column("cod_region")]
    public int CodRegion { get; set; }
    [ForeignKey("CodRegion")] // Lie cette propriété à la clé étrangère
    public Region Region { get; set; } // Propriété de navigation vers l'objet Region

    // Clé étrangère pour 'Producteur'
    [Column("ref_prod")]
    public int RefProd { get; set; }
    [ForeignKey("RefProd")]
    public Producteur Producteur { get; set; } // Propriété de navigation vers l'objet Producteur

    [Column("CodeDomaine")]
    [StringLength(50)]
    public string CodeDomaine { get; set; }

    // Propriétés de navigation pour les relations One-to-Many
    public ICollection<Secteur> Secteurs { get; set; }
    public ICollection<Assolement> Assolements { get; set; }

    public ICollection<Prevision> Previsions { get; set; }

    public Flux Flux { get; set; } // Propriété de navigation pour l'objet Flux associé à la Ferme
    
    public int SystemVersionId { get; set; }
    public SystemVersion SystemVersion { get; set; }
    }
}