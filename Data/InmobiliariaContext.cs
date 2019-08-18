using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.Models
{
    public class InmobiliariaContext : DbContext
    {
        public InmobiliariaContext (DbContextOptions<InmobiliariaContext> options)
            : base(options)
        {
        }

        public DbSet<Inmobiliaria.Models.Inmueble> Inmueble { get; set; }
    }
}
