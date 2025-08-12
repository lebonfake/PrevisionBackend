
namespace PrevisionBackend.Models
{
    public class EtapeFlux
{
    public int Id { get; set; }
  
    public int Ordre { get; set; }
    public string Nom { get; set; }

    public Flux Flux { get; set; }
    public ICollection<EtapePrev> EtapesPrev { get; set; }
        public ICollection<EtapeFluxValidateurPermission> EtapeFluxValidateurPermissions { get; set; }

    }


}