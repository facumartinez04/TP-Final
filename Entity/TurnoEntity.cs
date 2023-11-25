using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TurnoEntity
    {

        public int idTurno { get; set; }
        public ClienteEntity cliente { get; set; }
        public PeluqueroEntity peluquero { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime DiaTurno { get; set; }
        public TimeSpan Hora { get; set; }
        public string Estado { get; set; }
        public string Servicio { get; set; }
    }
}
