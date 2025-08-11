// Modèle pour la table de jointure 'Profile_Permissions' (relation Many-to-Many explicite)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrevisionBackend.Models
{
    public class ProfilePermission
{
    // Clé étrangère et partie de la clé primaire composite pour 'Profile'
    [Key] // Indique que c'est une partie de la clé primaire composite
    [Column(Order = 1)] // Définit l'ordre de la clé primaire composite
    public int ProfileID { get; set; }
    [ForeignKey("ProfileID")]
    public Profile Profile { get; set; } // Propriété de navigation vers l'objet Profile

    // Clé étrangère et partie de la clé primaire composite pour 'Permissions'
    [Key] // Indique que c'est une partie de la clé primaire composite
    [Column(Order = 2)] // Définit l'ordre de la clé primaire composite
    public int PermissionID { get; set; }
    [ForeignKey("PermissionID")]
    public Permission Permission { get; set; } // Propriété de navigation vers l'objet Permission

    // Vous pouvez ajouter d'autres propriétés si votre table de jointure en a.
    // Par exemple:
    // public DateTime GrantedDate { get; set; }
}
}