using System.ComponentModel.DataAnnotations;

namespace v4.Models
{
    public class Reparation
    {
        [Key]
        public int ReparationId{ get; set; }
       
        public string? Type { get; set; }
        public decimal Cout { get; set; }
        public DateTime DatededisponibiliteALaVente { get; set; }

        //jointure
        public int VoitureId { get; set; }
        public Voiture? Voiture { get; set; }


    }
}
