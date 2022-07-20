using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BcParksMvc.Models;

    public class BcParksMvcContext : DbContext
    {
        public BcParksMvcContext (DbContextOptions<BcParksMvcContext> options)
            : base(options)
        {
        }

        public DbSet<BcParksMvc.Models.Park> Park { get; set; } = default!;

        public DbSet<BcParksMvc.Models.ParkType>? ParkType { get; set; }
    }
