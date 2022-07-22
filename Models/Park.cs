using System.ComponentModel.DataAnnotations;

namespace BcParksMvc.Models
{
    public class Park
    {
        public int Id { get; set; }

        [Display(Name = "Park name")]
        public string Name { get; set; }

        [Display(Name = "Area (ha)")]
        public int AreaHa { get; set; }

        [Display(Name = "Area (acres)")]
        public int AreaAcres { get; set; }

        [Display(Name = "Established")]
        public int EstablishedYear { get; set; }

        public ICollection<ParkType> ParkTypes { get; set; }
    }
}