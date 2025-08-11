// Mod�le pour la table 'variete_champ'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
    public class VarieteChamp
{
    [Key]
    [Column("code_varchamp")]
    public int CodeVarChamp { get; set; }

    [Column("designation")]
    [StringLength(50)]
    public string Designation { get; set; }

    // Cl� �trang�re pour 'Variete'
    [Column("code_var")]
    public int CodeVar { get; set; }
    [ForeignKey("CodeVar")]
    public Variete Variete { get; set; } // Propri�t� de navigation vers l'objet Variete

    // Propri�t� de navigation pour les assolement associ�s (relation One-to-Many)
    public ICollection<Assolement> Assolements { get; set; }
}}