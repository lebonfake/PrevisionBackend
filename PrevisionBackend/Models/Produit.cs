// Modèle pour la table 'Produit'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
    public class Produit
{
    [Key]
    [Column("code_prod")]
    public int CodeProd { get; set; }

    [Column("designation")]
    [StringLength(50)]
    public string Designation { get; set; }

    // Propriété de navigation pour les variétés associées (relation One-to-Many)
    public ICollection<Variete> Varietes { get; set; }
}

}