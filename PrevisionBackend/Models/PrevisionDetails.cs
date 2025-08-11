namespace PrevisionBackend.Models
{
    public class PrevisionDetails
{
    public int Id { get; set; }
    public int IdPrevision { get; set; }
    public Secteur Secteur { get; set; }
    public int CycleId { get; set; }
    public int NumCulture { get; set; }
    public string Parcelle { get; set; }

    public Prevision Prevision { get; set; }
    public ICollection<LignePrevision> LignesPrevision { get; set; }
}
}