using System.ComponentModel.DataAnnotations;

namespace BcParksMvc.Models
{
    public class Park
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AreaHa { get; set; }
        public int AreaAcres { get; set; }
        public int EstablishedYear { get; set; }

        public ICollection<ParkType> ParkTypes { get; set; }
    }
}