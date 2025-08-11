// Mod�le pour la table 'Produit'
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

    // Propri�t� de navigation pour les vari�t�s associ�es (relation One-to-Many)
    public ICollection<Variete> Varietes { get; set; }
}

}