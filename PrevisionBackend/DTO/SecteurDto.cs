using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.DTO
{
    public class SecteurReadDto
    {
       
        public int Code { get; set; }

        
        public string Designation { get; set; }

       
        public float Superficie { get; set; }

      
        public string CodFerm { get; set; }

    }
}
