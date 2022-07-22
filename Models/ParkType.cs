using System.ComponentModel.DataAnnotations;

namespace BcParksMvc.Models
{
    public class ParkType
    {
        public int Id { get; set; }

        [Display(Name = "Park type")]
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public ICollection<Park>? Parks { get; set; }
    }
}