﻿using Entity;
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

        public int agregarClienteDevolverID(ClienteEntity cliente)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    
                    var cli = new Cliente
                    {
                        NOMBRE_APELLIDO = cliente.nombreApellido,
                        TELEFONO = cliente.telefono,
                        usuario = cliente.usuario,

                    };

                    turnosContext.Cliente.Add(cli);
                    turnosContext.SaveChanges();
                    turnosContext.Entry(cli).GetDatabaseValues();
                    return cli.ID_CLIENTE;
                    
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


        public ClienteEntity getByID(int id)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Cliente cliente = turnosContext.Cliente.FirstOrDefault(t => t.ID_CLIENTE == id);
                    return getClienteEntitybyCliente(cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public ClienteEntity getByUsuario(string usuario)
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


        public List<ClienteEntity> listarClientes()
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {

                    List<Cliente> listaCliente = turnosContext.Cliente.ToList();

                    return listaCliente.Select(s => getClienteEntitybyCliente(s)).ToList();
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
