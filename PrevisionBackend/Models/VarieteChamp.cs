// Modèle pour la table 'variete_champ'
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

    // Clé étrangère pour 'Variete'
    [Column("code_var")]
    public int CodeVar { get; set; }
    [ForeignKey("CodeVar")]
    public Variete Variete { get; set; } // Propriété de navigation vers l'objet Variete

    // Propriété de navigation pour les assolement associés (relation One-to-Many)
    public ICollection<Assolement> Assolements { get; set; }
}}