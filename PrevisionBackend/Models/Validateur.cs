namespace PrevisionBackend.Models
{
    public class Validateur
    {
        public int Id { get; set; }
        public User User { get; set; }

        public ICollection<ValidateursEtape> ValidateursEtapes { get; set; }
    }
}