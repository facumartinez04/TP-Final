using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClienteEntity
    {
        public int idCliente {  get; set; }
        public string nombreApellido { get; set; }
        public string telefono { get; set; }    
         public string usuario { get; set; }

        public int rol { get; set; }

    }
}
