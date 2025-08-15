namespace PrevisionBackend.Models
{
    public class SystemVersion
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        
        public ICollection<Version> Versions { get; set; }

        public ICollection<Ferme> Fermes { get; set; }
     }
}
