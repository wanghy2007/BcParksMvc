using Microsoft.EntityFrameworkCore;

namespace BcParksMvc.Models
{
    public static class SeedParks
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BcParksMvcContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BcParksMvcContext>>()))
            {
                if (context.Park.Any())
                {
                    return;
                }

                ParkType PP = context.ParkType.Where(pt => pt.Abbreviation == "PP").FirstOrDefault();
                ParkType PPStar = context.ParkType.Where(pt => pt.Abbreviation == "PP*").FirstOrDefault();
                ParkType RA = context.ParkType.Where(pt => pt.Abbreviation == "RA").FirstOrDefault();
                ParkType C = context.ParkType.Where(pt => pt.Abbreviation == "C").FirstOrDefault();
                ParkType PA = context.ParkType.Where(pt => pt.Abbreviation == "PA").FirstOrDefault();
                ParkType ER = context.ParkType.Where(pt => pt.Abbreviation == "ER").FirstOrDefault();
                context.Park.AddRange(
                    new Park
                    {
                        Name = "Adams Lake Provincial Park",
                        AreaHa = 262,
                        AreaAcres = 650,
                        EstablishedYear = 1996,
                        ParkTypes = new List<ParkType> { PP }
                    },
                    new Park
                    {
                        Name = "Akamina-Kishinena Provincial Park",
                        AreaHa = 10921,
                        AreaAcres = 26990,
                        EstablishedYear = 1995,
                        ParkTypes = new List<ParkType> { PP }
                    },
                    new Park
                    {
                        Name = "Alexandra Bridge Provincial Park",
                        AreaHa = 51,
                        AreaAcres = 130,
                        EstablishedYear = 1984,
                        ParkTypes = new List<ParkType> { PP }
                    },
                    new Park
                    {
                        Name = "Aleza Lake Ecological Reserve",
                        AreaHa = 269,
                        AreaAcres = 660,
                        EstablishedYear = 1978,
                        ParkTypes = new List<ParkType> { ER }
                    },
                    new Park
                    {
                        Name = "Alice Lake Provincial Park",
                        AreaHa = 411,
                        AreaAcres = 1020,
                        EstablishedYear = 1956,
                        ParkTypes = new List<ParkType> { PP }
                    },
                    new Park
                    {
                        Name = "Allison Harbour Marine Provincial Park",
                        AreaHa = 132,
                        AreaAcres = 330,
                        EstablishedYear = 2008,
                        ParkTypes = new List<ParkType> { PP }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}