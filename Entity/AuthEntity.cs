using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AuthEntity
    {
        public string nombreyApellido {get;set;}
        public string Usuario { get; set; }
        public string password { get; set; }    

        public string telefono { get; set; }


        public int idCliente { get; set; }

        public int rol { get; set; }

    }
}
