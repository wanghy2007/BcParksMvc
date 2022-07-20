using Microsoft.EntityFrameworkCore;

namespace BcParksMvc.Models
{
    public static class SeedParkTypes
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BcParksMvcContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BcParksMvcContext>>()))
            {
                if (context.ParkType.Any())
                {
                    return;
                }

                context.ParkType.AddRange(
                    new ParkType
                    {
                        Name = "Class A Provincial Park",
                        Abbreviation = "PP"
                    },
                    new ParkType
                    {
                        Name = "Class B/C Provincial Park",
                        Abbreviation = "PP*"
                    },
                    new ParkType
                    {
                        Name = "Recreation Area",
                        Abbreviation = "RA"
                    },
                    new ParkType
                    {
                        Name = "Conservancy",
                        Abbreviation = "C"
                    },
                    new ParkType
                    {
                        Name = "Protected Areas",
                        Abbreviation = "PA"
                    },
                    new ParkType
                    {
                        Name = "Ecological Reserve",
                        Abbreviation = "ER"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}