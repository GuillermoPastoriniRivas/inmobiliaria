using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RoomsInmuebleViewModel
    {
        public List<Inmueble> Inmuebles { get; set; }
        public SelectList Rooms { get; set; }
        public int RoomsInmueble { get; set; }
        public SelectList Operaciones { get; set; }
        public string OperacionInmueble { get; set; }
        public string SearchString { get; set; }
    }
}
