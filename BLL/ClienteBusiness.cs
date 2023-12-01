using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBusiness
    {

        private ClienteDAO clienteDAO = new ClienteDAO();

        public List<ClienteEntity> listarClientes()
        {
            return clienteDAO.listarClientes();
        }
    }
}
