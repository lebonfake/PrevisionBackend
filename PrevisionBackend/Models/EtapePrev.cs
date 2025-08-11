namespace PrevisionBackend.Models
{
     public enum StatutEtapePrev
    {
        Validee,
        EnAttente,
        PasEncore,
        Annulee
    }

    public class EtapePrev
    {
        public int Id { get; set; }
        public StatutEtapePrev Statut { get; set; }

        public int PrevisionId { get; set; }
        public int EtapeFluxId { get; set; }
        public Prevision Prevision { get; set; }
        public EtapeFlux EtapeFlux { get; set; }
    }
}