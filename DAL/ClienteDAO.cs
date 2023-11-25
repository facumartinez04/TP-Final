using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAO
    {


        public void agregarCliente(ClienteEntity cliente)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Cliente cli = new Cliente
                    {
                        ID_CLIENTE = cliente.idCliente,
                        NOMBRE_APELLIDO = cliente.nombreApellido,
                        TELEFONO = cliente.telefono,
                        usuario = cliente.usuario,

                    };

                    turnosContext.Cliente.Add(cli);
                    turnosContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public void EliminarCliente(int id)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Cliente cli = turnosContext.Cliente.FirstOrDefault(t => t.ID_CLIENTE == id);

                    turnosContext.Cliente.Remove(cli);
                    turnosContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ClienteEntity getbyID(string usuario)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Cliente cliente = turnosContext.Cliente.FirstOrDefault(t => t.usuario == usuario);
                    return getClienteEntitybyCliente(cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private ClienteEntity getClienteEntitybyCliente(Cliente cliente)
        {

            if (cliente == null) return null;

            return new ClienteEntity
            {
                nombreApellido = cliente.NOMBRE_APELLIDO,
                idCliente = cliente.ID_CLIENTE,
                telefono = cliente.TELEFONO
            };

        }
    }
}
