// Modèle pour la table 'Permissions'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PrevisionBackend.Models
{
public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PermissionID { get; set; }

    // Clé étrangère pour 'Module'
    public int Module_Permissions { get; set; } // Mappé à la colonne 'Module_Permissions'
    [ForeignKey("Module_Permissions")]
    public Module Module { get; set; } // Propriété de navigation vers l'objet Module

    [StringLength(50)]
    public string PermissionName { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; }

    // Propriété de navigation pour les profils associés à cette permission (relation Many-to-Many via Profile_Permissions)
    public ICollection<ProfilePermission> ProfilePermissions { get; set; }
}

}