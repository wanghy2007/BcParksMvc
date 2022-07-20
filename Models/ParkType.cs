using System.ComponentModel.DataAnnotations;

namespace BcParksMvc.Models
{
    public class ParkType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Park> Parks { get; set; }
    }
}