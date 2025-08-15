using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.DTO
{
    public class CycleReadDto
    {
        
        public int CodeCycle { get; set; }

        
        public string Designation { get; set; }

    }
}
