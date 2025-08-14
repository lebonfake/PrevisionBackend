namespace PrevisionBackend.Models
{
    public class Version
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartDay { get; set; } //0-6 sunday to saturday
        public int EndDay { get; set; }
        public int SystemVersionId { get; set; }
        public SystemVersion SystemVersion { get; set; }

    }
}
