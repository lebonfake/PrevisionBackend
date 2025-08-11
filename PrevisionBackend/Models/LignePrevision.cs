namespace PrevisionBackend.Models
{
    public class LignePrevision
{
    public int Id { get; set; }
    public int IdPrevisionDetails { get; set; }
    public decimal Valeur { get; set; }
    public DateTime Date { get; set; }

    public PrevisionDetails PrevisionDetails { get; set; }
}}
