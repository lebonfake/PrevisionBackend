namespace PrevisionBackend.Models
{
    public class ValidateurPermissionEtape
    {
        public int Id { get; set; }
        public PermissionType PermissionPrev { get; set; }
        public ValidateursEtape ValidateurEtape { get; set; }
    }
}
