using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Inmueble
    {
        public int Id { get; set; }
        public string Ubicación { get; set; }
        public string Descripcion { get; set; }
        [Display(Name = "Fecha de Publicación")]
        [DataType(DataType.Date)]
        public DateTime FechaDePublicación { get; set; }
        public int Superficie { get; set; }
        [Display(Name = "Baños")]
        public int Baths { get; set; }
        [Display(Name = "Dormitorios")]
        public int Rooms { get; set; }
        public string Operacion { get; set; }
        public int Precio { get; set; }
    }
}
