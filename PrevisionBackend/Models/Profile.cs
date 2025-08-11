// Mod�le pour la table 'Profile'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
public class Profile
{
    [Key] // Indique que 'ProfileID' est la cl� primaire
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // L'ID est g�n�r� par la base de donn�es
    public int ProfileID { get; set; }

    [StringLength(50)] // Longueur maximale de 50 caract�res
    public string ProfileName { get; set; }

    [Column(TypeName = "nvarchar(max)")] // Mappe � un type de colonne SQL 'nvarchar(max)'
    public string Description { get; set; }

    // Propri�t� de navigation pour les utilisateurs ayant ce profil (relation One-to-Many)
    public ICollection<User> Users { get; set; }

    // Propri�t� de navigation pour les permissions associ�es � ce profil (relation Many-to-Many via Profile_Permissions)
    public ICollection<ProfilePermission> ProfilePermissions { get; set; }
}
}