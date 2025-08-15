using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
    // Modèle pour la table de jonction 'UserFerme'
    public class UserFerme
    {
        // Clé étrangère et partie de la clé primaire composite pour 'User'
        [Column(Order = 1)]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Clé étrangère et partie de la clé primaire composite pour 'Ferme'
        [Column(Order = 2)]
        [StringLength(50)] // Doit correspondre à la longueur de CodFerm dans Ferme
        public string FermeId { get; set; }
        [ForeignKey("FermeId")]
        public Ferme Ferme { get; set; }

        // Vous pouvez ajouter d'autres propriétés à votre table de jonction si nécessaire,
        // par exemple, une date d'association, un rôle spécifique, etc.
        // public DateTime DateAssociation { get; set; } = DateTime.UtcNow;
    }
}
