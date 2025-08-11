
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{// Modèle pour la table 'Module' (assumé, car 'Permissions' y fait référence)
// Vous devrez peut-être ajuster cette classe en fonction de votre structure 'Module' réelle.
public class Module
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ModuleID { get; set; }

    [StringLength(50)]
    public string ModuleName { get; set; }

    // Propriété de navigation pour les permissions associées à ce module
    public ICollection<Permission> Permissions { get; set; }
}
}