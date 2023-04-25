using Microsoft.EntityFrameworkCore.Query;
using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace v4.Models
{
    public class Voiture
    {
        [Key]
        public int VoitureId { get; set; }
        public string? AnneeDeMiseEnCirculation { get; set; }
        public string? Marque { get; set; }
        public string? Modele { get; set; }
        public string? Finition { get; set; }
        public DateTime? DateAchat { get; set; }

        public decimal?  PrixAchat {get; set; }
        public decimal? PrixVente { get; set; }

        //   public bool IsDisponible(TrustedSignerAllowListEntry;)

        //jointure
        public ICollection<Reparation>? Reparations { get; set; }
    }

}

