namespace PrevisionBackend.Models
{
    public class Version
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDay { get; set; }
        public DateOnly EndDay { get; set; }
        public int SystemVersionId { get; set; }
        public SystemVersion SystemVersion { get; set; }

    }
}
