// Mod�le pour la table 'Assolement'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PrevisionBackend.Models
{
public class Assolement
{
    [Key]
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indique que l'ID est g�n�r� par la base de donn�es
    public int ID { get; set; }

    // Cl� �trang�re pour 'Secteur'
    [Column("secteur")]
    public int SecteurId { get; set; } // Renomm� pour �viter la collision avec la propri�t� de navigation
    [ForeignKey("SecteurId")]
    public Secteur Secteur { get; set; }

    // Cl� �trang�re pour 'Cycle'
    [Column("cycle")]
    public int CycleId { get; set; } // Renomm�
    [ForeignKey("CycleId")]
    public Cycle Cycle { get; set; }

    // Cl� �trang�re pour 'Ferme'
    [Column("ferme")]
    [StringLength(50)]
    public string FermeCod { get; set; } // Renomm�
    [ForeignKey("FermeCod")]
    public Ferme Ferme { get; set; }

    // Cl� �trang�re pour 'VarieteChamp'
    [Column("variete_champ")]
    public int VarieteChampId { get; set; } // Renomm�
    [ForeignKey("VarieteChampId")]
    public VarieteChamp VarieteChamp { get; set; }

    [Column("parcelle")]
    [StringLength(10)]
    public string Parcelle { get; set; }

    [Column("num_culture")]
    public int NumCulture { get; set; }

    [Column("Date_plantation")]
    public DateTime DatePlantation { get; set; }

    [Column("Date_recolte")]
    public DateTime DateRecolte { get; set; }

    [Column("Date_arrachage")]
    public DateTime DateArrachage { get; set; }

    [Column("superficiePlante")]
    public float SuperficiePlante { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column("hasRecieved")]
    public bool HasRecieved { get; set; }

    // La contrainte UNIQUE (ferme, secteur, cycle, parcelle, num_culture, variete_champ)
    // sera configur�e dans le DbContext en utilisant la Fluent API.
    // Elle ne peut pas �tre exprim�e directement via des attributs sur la classe de mod�le.
}
}