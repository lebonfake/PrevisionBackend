
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{// Mod�le pour la table 'Module' (assum�, car 'Permissions' y fait r�f�rence)
// Vous devrez peut-�tre ajuster cette classe en fonction de votre structure 'Module' r�elle.
public class Module
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ModuleID { get; set; }

    [StringLength(50)]
    public string ModuleName { get; set; }

    // Propri�t� de navigation pour les permissions associ�es � ce module
    public ICollection<Permission> Permissions { get; set; }
}
}