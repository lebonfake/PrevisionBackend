// Mod�le pour la table 'variete'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
    public class Variete
{
    [Key]
    [Column("code_var")]
    public int CodeVar { get; set; }

    [Column("designation")]
    [StringLength(50)]
    public string Designation { get; set; }

    // Cl� �trang�re pour 'Produit'
    [Column("code_prod")]
    public int CodeProd { get; set; }
    [ForeignKey("CodeProd")]
    public Produit Produit { get; set; } // Propri�t� de navigation vers l'objet Produit

    // Propri�t� de navigation pour les vari�t�s de champ associ�es (relation One-to-Many)
    public ICollection<VarieteChamp> VarieteChamps { get; set; }
}
}