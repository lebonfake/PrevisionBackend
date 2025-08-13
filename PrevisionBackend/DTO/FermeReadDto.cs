using System.ComponentModel.DataAnnotations;

namespace PrevisionBackend.DTO
{
    public class FermeReadDto
    {
        public string Id { get; set; }
        public string Nom { get; set; }

    }
    public class AffectFermeRequestDto
    {
        [Required]
        public List<string> FermeId { get; set; } // The ID of the farm to affect

        [Required]
        public int FluxId { get; set; } // The ID of the flux to associate
    }

}
