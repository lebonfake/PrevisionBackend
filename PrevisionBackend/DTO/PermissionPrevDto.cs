using System.ComponentModel.DataAnnotations;

namespace PrevisionBackend.DTO
{
    // DTO for reading/response of PermissionPrev
    public class PermissionPrevReadDto
    {
        public int Id { get; set; }
        public string Permissions { get; set; } // Representing the enum as a string for reading
    }
}
