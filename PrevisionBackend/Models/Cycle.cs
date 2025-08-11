// Modèle pour la table 'cycle'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrevisionBackend.Models
{
public class Cycle
{
    [Key]
    [Column("code_cycle")]
    public int CodeCycle { get; set; }

    [Column("designation")]
    [StringLength(50)]
    public string Designation { get; set; }

    [Column("date_start")]
    public DateTime DateStart { get; set; }

    [Column("date_end")]
    public DateTime DateEnd { get; set; }

    // Propriété de navigation pour les assolement associés (relation One-to-Many)
    public ICollection<Assolement> Assolements { get; set; }
}
}