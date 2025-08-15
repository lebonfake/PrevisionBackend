// Modèle pour la table 'Users'
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrevisionBackend.Models
{
    public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }

    [Required] // Le champ ne peut pas être nul
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(255)]
    public string PasswordHash { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(50)]
    public string PhoneNumber { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string LastName { get; set; }

    // Clé étrangère pour 'Profile'
    public int ProfileID { get; set; } // Note: Assuming Profile is required, otherwise use int?
    [ForeignKey("ProfileID")]
    public Profile Profile { get; set; } // Propriété de navigation vers l'objet Profile

    public DateTime CreatedAt { get; set; }

    public ICollection<UserFerme> UserFermes { get; set; }
                
}
}