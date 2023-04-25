using System.ComponentModel.DataAnnotations;
namespace v4.Models
{
    public class InfoReparationVoiture
    {
        public int VoitureId { get; set; }
        public string ?Marque { get; set; }
            public string? Modele { get; set; }
            public int NombreReparations { get; set; }
           
    }
}
