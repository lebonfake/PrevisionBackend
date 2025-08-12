namespace PrevisionBackend.Models

{
    public enum PermissionType
    {
        Lecture,
        Ecriture,
        Validation
    }

    public class PermissionPrev
    {
        public int Id { get; set; }
        public PermissionType Permissions { get; set; }
        public ICollection<EtapeFluxValidateurPermission> EtapeFluxValidateurPermissions { get; set; }
    }
}
