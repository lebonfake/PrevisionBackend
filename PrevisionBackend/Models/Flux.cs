namespace PrevisionBackend.Models
{
    public class Flux
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public int NombreEtapes { get; set; }
    public ICollection<Ferme> Fermes { get; set; }

    public ICollection<EtapeFlux> Etapes { get; set; }
}}