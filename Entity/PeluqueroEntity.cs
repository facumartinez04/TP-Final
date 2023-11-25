using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PeluqueroEntity
    {
        public int idPeluquero { get; set; }
        public String nombreApellidoPeluquero { get; set; }
        public String telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime fechaIngreso { get; set; }
    }
}
