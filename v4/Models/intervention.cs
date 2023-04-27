using v4.Models;

namespace v4.Models
{
    public class Interventions

    {
        public int InterventionsId { get; set; }

        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
        public ICollection<Reparation>? Reparations { get; set; }

    }
}
