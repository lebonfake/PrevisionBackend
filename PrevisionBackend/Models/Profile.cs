// Modèle pour la table 'Profile'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
public class Profile
{
    [Key] // Indique que 'ProfileID' est la clé primaire
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // L'ID est généré par la base de données
    public int ProfileID { get; set; }

    [StringLength(50)] // Longueur maximale de 50 caractères
    public string ProfileName { get; set; }

    [Column(TypeName = "nvarchar(max)")] // Mappe à un type de colonne SQL 'nvarchar(max)'
    public string Description { get; set; }

    // Propriété de navigation pour les utilisateurs ayant ce profil (relation One-to-Many)
    public ICollection<User> Users { get; set; }

    // Propriété de navigation pour les permissions associées à ce profil (relation Many-to-Many via Profile_Permissions)
    public ICollection<ProfilePermission> ProfilePermissions { get; set; }
}
}