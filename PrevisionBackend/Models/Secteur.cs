// Modèle pour la table 'Secteur'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrevisionBackend.Models
{
    public class Secteur
{
    [Key]
    [Column("code")]
    public int Code { get; set; }

    [Column("designation")]
    [StringLength(50)]
    public string Designation { get; set; }

    [Column("superficie")]
    public float Superficie { get; set; }

    // Clé étrangère pour 'Ferme'
    [Column("cod_ferm")]
    [StringLength(50)]
    public string CodFerm { get; set; }
    [ForeignKey("CodFerm")]
    public Ferme Ferme { get; set; } // Propriété de navigation vers l'objet Ferme

    // Propriété de navigation pour les assolement associés (relation One-to-Many)
    public ICollection<Assolement> Assolements { get; set; }
}
}