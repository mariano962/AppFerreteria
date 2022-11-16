using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppFerreteria.Models;

    public class AppFerreteriaContext : DbContext
    {
        public AppFerreteriaContext (DbContextOptions<AppFerreteriaContext> options)
            : base(options)
        {
        }

        public DbSet<AppFerreteria.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<AppFerreteria.Models.Motosierra>? Motosierra { get; set; }

        public DbSet<AppFerreteria.Models.Rental>? Rental { get; set; }

        public DbSet<AppFerreteria.Models.Return>? Return { get; set; }
    }
