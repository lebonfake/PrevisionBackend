namespace PrevisionBackend.Models
{
    public enum TypePrevision
{
    Journaliere,
    Hebdo,
    SixWeeks
}

public enum StatutPrevision
{
    Valide,
    EnAttente,
    Annule,

}

public class Prevision
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TypePrevision Type { get; set; }
    public string FermeId { get; set; } // Renommé pour éviter la collision avec la propriété de navigation
    public Ferme Ferme { get; set; }
    public int? Version { get; set; }
    public int CreePar { get; set; }
    public StatutPrevision Statut { get; set; }

    public ICollection<PrevisionDetails> Details { get; set; }
    public ICollection<EtapePrev> EtapesPrev { get; set; }
}
}