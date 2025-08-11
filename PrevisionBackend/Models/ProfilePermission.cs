// Mod�le pour la table de jointure 'Profile_Permissions' (relation Many-to-Many explicite)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrevisionBackend.Models
{
    public class ProfilePermission
{
    // Cl� �trang�re et partie de la cl� primaire composite pour 'Profile'
    [Key] // Indique que c'est une partie de la cl� primaire composite
    [Column(Order = 1)] // D�finit l'ordre de la cl� primaire composite
    public int ProfileID { get; set; }
    [ForeignKey("ProfileID")]
    public Profile Profile { get; set; } // Propri�t� de navigation vers l'objet Profile

    // Cl� �trang�re et partie de la cl� primaire composite pour 'Permissions'
    [Key] // Indique que c'est une partie de la cl� primaire composite
    [Column(Order = 2)] // D�finit l'ordre de la cl� primaire composite
    public int PermissionID { get; set; }
    [ForeignKey("PermissionID")]
    public Permission Permission { get; set; } // Propri�t� de navigation vers l'objet Permission

    // Vous pouvez ajouter d'autres propri�t�s si votre table de jointure en a.
    // Par exemple:
    // public DateTime GrantedDate { get; set; }
}
}