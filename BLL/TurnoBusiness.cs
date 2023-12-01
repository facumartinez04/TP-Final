using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace BLL
{

    public class TurnoBusiness
    {
        private TurnoDAO turnosDAO = new TurnoDAO();

        private ClienteDAO clienteDAO = new ClienteDAO();

        public List<TurnoEntity> listaTurnos()
        {
            return turnosDAO.listarTurnos();
        }




        public void agregarTurnoCliente(TurnoEntity turno)
        {
            turno.Estado = "Asignado";
            turno.FechaRegistro = DateTime.Now.Date;
            ClienteEntity cliente = clienteDAO.getByUsuario(turno.cliente.usuario);
            if (turno.DiaTurno.Date < DateTime.Now.Date) throw new Exception("Debe ser un dia mas adelante");
            bool TurnoRepetido = turnosDAO.listarTurnos().Any(x => x.peluquero.idPeluquero == turno.peluquero.idPeluquero && x.DiaTurno.Date == turno.DiaTurno.Date && x.Hora == turno.Hora);
            if (TurnoRepetido) throw new Exception("El peluquero ya tiene un turno asignado a esa hora");
            if (cliente == null)
            {
                clienteDAO.agregarCliente(new ClienteEntity
                {
                    nombreApellido = turno.cliente.nombreApellido,
                    telefono = turno.cliente.telefono,
                    usuario = turno.cliente.usuario
                });
                cliente = clienteDAO.getByUsuario(turno.cliente.usuario);
            }
            turno.cliente.idCliente = cliente.idCliente;


            using (var transaction = new TransactionScope())
            {
                turnosDAO.agregarTurno(turno);
                transaction.Complete();
            }
        }


        public void agregarTurnoAdmin(TurnoEntity turno)
        {

            turno.Estado = "Asignado";
            turno.FechaRegistro = DateTime.Now.Date;
            ClienteEntity cliente = null;
            if (turno.DiaTurno.Date < DateTime.Now.Date) throw new Exception("Debe ser un dia mas adelante");
            bool TurnoRepetido = turnosDAO.listarTurnos().Any(x => x.peluquero.idPeluquero == turno.peluquero.idPeluquero && x.DiaTurno.Date == turno.DiaTurno.Date && x.Hora == turno.Hora);
            if (TurnoRepetido) throw new Exception("El peluquero ya tiene un turno asignado a esa hora");
            using (var transaction = new TransactionScope())
            {
                if (turno.cliente.idCliente != 0)
            {
                cliente = clienteDAO.getByID(Convert.ToInt32(turno.cliente.idCliente));
                cliente.telefono = cliente.telefono;
                cliente.nombreApellido = cliente.nombreApellido;
            }
            else
            {
                
                int idCl = clienteDAO.agregarClienteDevolverID(new ClienteEntity
                {
                    nombreApellido = turno.cliente.nombreApellido,
                    telefono = turno.cliente.telefono
                });

                turno.cliente.idCliente = idCl;
            }
           

                turnosDAO.agregarTurno(turno);
                transaction.Complete();
            }
        }

        
            
        public void eliminarTurno(int id)
        {
            TurnoEntity turnoBuscado =  turnosDAO.getbyID(id);
            if (turnoBuscado == null) throw new Exception("El id que ingreso no existe");

            using (var transaction = new TransactionScope())
            {

                turnosDAO.EliminarTurno(id);
                  transaction.Complete();
            }
        }

        public void editarTurno(TurnoEntity turnoeditar)
        {
            if (turnoeditar.idTurno == 0) throw new Exception("Ingresa un id");
            if (turnoeditar.DiaTurno.Date < DateTime.Now.Date) throw new Exception("Debe ser un dia mas adelante");
            TurnoEntity turnoBuscado = turnosDAO.getbyID(turnoeditar.idTurno);
            if (turnoBuscado == null) throw new Exception("El id que ingreso no existe");
            using (var transaction = new TransactionScope())
            {
                turnosDAO.EditarTurno(turnoeditar);

                transaction.Complete();
            }
        }


    }
}
