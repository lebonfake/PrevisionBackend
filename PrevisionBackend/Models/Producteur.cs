
// Modèle pour la table 'Producteur'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
    public class Producteur
{
    [Key]
    [Column("code_producteur")]
    public int CodeProducteur { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; }

    [Column("type")]
    [StringLength(50)]
    public string Type { get; set; }

    // Propriété de navigation pour les fermes associées à ce producteur (relation One-to-Many)
    public ICollection<Ferme> Fermes { get; set; }
}
}
