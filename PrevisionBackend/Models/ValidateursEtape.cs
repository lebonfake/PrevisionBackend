
namespace PrevisionBackend.Models{
    public class ValidateursEtape
    {
        public int Id { get; set; }
        public int EtapeFluxId { get; set; }
        public int ValidateurId { get; set; }

        public EtapeFlux EtapeFlux { get; set; }
        public Validateur Validateur { get; set; }
        public ICollection<ValidateurPermissionEtape> PermissionsEtape { get; set; }
    }
}