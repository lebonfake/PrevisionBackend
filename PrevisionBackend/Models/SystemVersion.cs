namespace PrevisionBackend.Models
{
    public class SystemVersion
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int NombreVersion {  get; set; }
        public ICollection<Version> Versions { get; set; }
    }
}
